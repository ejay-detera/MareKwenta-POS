using Mare_POS.Authentication;
using Mare_POS.Ticket_Components;
using Mare_POS.TicketFolder.Database;
using Mare_POS.TicketFolder.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace Mare_POS
{
    public partial class TicketForm : UserControl
    {
        public event Action NavigateToTicketCoffee;
        public event Action NavigateToTicketForm;

        private decimal currentDiscountAmount = 0;
        private decimal currentDiscountRate = 0;

        private int transactionNo;

        public TicketForm()
        {
            InitializeComponent();

            // Wire the event manually
            txtManualAmount.KeyUp += txtManualAmount_KeyUp;

            this.Load += TicketForm_Load;

            transactionNo = TicketPaymentBackend.GetNextTransactionNo();
        }

        private List<Item> currentOrder = new List<Item>();
        public event Action<Item> ItemAdded;

        private decimal cashReceived = 0;
        private decimal precalculated = 0;


        // ✅ Add event handler method for child controls
 private void HandleProductSelection(string productName)
{
    // Get ProductID dynamically from database
    int productId = ProductDataAccess.GetProductId(productName);
    if (productId == 0)
    {
        MessageBox.Show($"Product '{productName}' not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        return;
    }
    
    var popup = new ProductComponent();
    popup.StartPosition = FormStartPosition.CenterParent;
    popup.ProductId = productId;
    popup.ProductName = productName;
    
    string category = DetermineCategory(productName);
    if (popup.ShowDialog(this) == DialogResult.OK)
    {
        // ✅ Get the calculated total from the popup
        decimal calculatedTotal = popup.Total;
        
        // ✅ Check and deduct inventory BEFORE adding to order
        if (!DeductInventoryForProduct(productId, popup.Quantity, popup.SelectedSize, popup.SelectedType, category))
        {
            // Inventory deduction failed, don't add the item
            return;
        }
        
        // ✅ Use centralized method with the calculated total
        AddItemToOrder(productId, productName, popup.SelectedSize, popup.SelectedType, popup.Quantity, calculatedTotal);
    }
}
        private bool DeductInventoryForProduct(int productId, int orderQuantity, string size, string type, string category)
        {
            try
            {
                // Generate category code based on category, type, and size
                string categoryCode = GenerateCategoryCode(category, type, size);
                // Get inventory items needed for this specific product variant from ProductIngredient table
                var productIngredients = ProductDataAccess.GetProductIngredients(productId, categoryCode);

                if (productIngredients == null || productIngredients.Count == 0)
                {
                    // Product has no ingredients defined for this variant, skip inventory deduction
                    return true;
                }

                // Check if we have enough inventory for all ingredients first
                List<(int InventoryId, int RequiredQuantity, int CurrentStock)> inventoryChecks = new List<(int, int, int)>();

                foreach (var ingredient in productIngredients)
                {
                    int currentStock = InventoryDataAccess.GetInventoryQuantity(ingredient.InventoryID);
                    int requiredQuantity = ingredient.Quantity * orderQuantity; // ingredient qty per product * order qty

                    inventoryChecks.Add((ingredient.InventoryID, requiredQuantity, currentStock));

                    if (currentStock < requiredQuantity)
                    {
                        string inventoryName = InventoryDataAccess.GetInventoryName(ingredient.InventoryID);
                        MessageBox.Show($"Insufficient inventory for '{inventoryName}' ({categoryCode}). Required: {requiredQuantity}, Available: {currentStock}",
                                      "Insufficient Inventory", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                // If we reach here, we have enough inventory for all ingredients
                // Now deduct the quantities
                foreach (var check in inventoryChecks)
                {
                    bool success = InventoryDataAccess.DeductInventoryQuantity(check.InventoryId, check.RequiredQuantity);
                    if (!success)
                    {
                        MessageBox.Show($"Failed to deduct inventory for InventoryID: {check.InventoryId}",
                                      "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deducting inventory: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Helper method to generate category codes
        private string GenerateCategoryCode(string category, string type, string size)
        {
            string categoryPrefix = "";
            string typeCode = "";
            string sizeCode = "";

            //MessageBox.Show($"Category: {category}, Type: {type}, Size: {size}");

            // Category prefix
            switch (category.ToLower())
            {
                case "coffee":
                    categoryPrefix = "c";
                    break;
                case "non-coffee":
                case "non coffee":
                    categoryPrefix = "n";
                    break;
                case "food":
                    return "food"; 
                default:
                    categoryPrefix = "c"; // Default to coffee
                    break;
            }

            // Type code
            switch (type.ToLower())
            {
                case "hot":
                    typeCode = "h";
                    break;
                case "cold":
                    typeCode = "c";
                    break;
                default:
                    typeCode = "h"; // Default to hot
                    break;
            }

            // Size code
            switch (size.ToLower())
            {
                case "grande":
                    sizeCode = "g";
                    break;
                case "venti":
                    sizeCode = "v";
                    break;
                default:
                    sizeCode = "g"; // Default to grande
                    break;
            }

            return categoryPrefix + typeCode + sizeCode;
        }

        private void HandleItemAddedFromChild(Item item)
        {

            try
            {
                AddItemToOrder(item.ProductID, item.ProductName, item.ProductSize, item.ProductType, item.Quantity, item.Amount);

                //MessageBox.Show($"✅ AddItemToOrder completed successfully", "Debug - After AddItemToOrder");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"❌ ERROR in HandleItemAddedFromChild:\n{ex.Message}\n\nStack Trace:\n{ex.StackTrace}", "Error");
            }
        }

        private void AddItemToOrder(int productId, string productName, string size, string type, int quantity, decimal preCalculatedAmount)
        {


            var currentEmployeeID = GetCurrentEmployeeID();
            string category = DetermineCategory(productName);

            decimal itemTotal = preCalculatedAmount;

            // Add to cart with the CORRECT amount
            currentOrder.Add(new Item
            {
                EmployeeID = currentEmployeeID,
                ProductID = productId,
                ProductName = productName,
                ProductSize = size ?? "Grande",
                ProductType = type ?? "Hot",
                Quantity = quantity,
                Amount = itemTotal, 
                Category = category
            });

            AddItemToTicketPanel(currentOrder.Last());
            UpdateSubtotalLabel();

        }
        private void lblTypeTemplate_Click(object sender, EventArgs e)
        {
            // This is just to ensure the template label is not empty
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            AllPanel.Visible = false;
            CoffeePanel.Visible = false;
            NonCoffeePanel.Visible = false;
            FoodPanel.Visible = true;

            // ✅ If you want to use the new event-driven approach, uncomment this:
            // ShowTicketFood();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cuiButton8_Click(object sender, EventArgs e)
        {

        }
        private void SetupComponents()
        {
            // Recursively find all user controls even inside panels
            List<Control> GetAllControls(Control parent)
            {
                var all = new List<Control>();
                foreach (Control c in parent.Controls)
                {
                    all.Add(c);
                    all.AddRange(GetAllControls(c));
                }
                return all;
            }

            var allControls = GetAllControls(this);

            ticketFood1 = allControls.OfType<TicketFood>().FirstOrDefault();
            ticketCoffee1 = allControls.OfType<TicketCoffee>().FirstOrDefault();
            ticketNonCoffee1 = allControls.OfType<TicketNonCoffee>().FirstOrDefault();

            if (ticketFood1 != null)
            {
                ticketFood1.ItemAdded += HandleItemAddedFromChild;
            }
            else
            {
                MessageBox.Show("❌ ticketFood1 is NULL.");
            }

            if (ticketCoffee1 != null)
            {
                ticketCoffee1.ItemAdded += HandleItemAddedFromChild;
            }
            else
            {
                MessageBox.Show("❌ ticketCoffee1 is NULL.");
            }

            if (ticketNonCoffee1 != null)
            {
                ticketNonCoffee1.ItemAdded += HandleItemAddedFromChild;
            }
            else
            {
                MessageBox.Show("❌ ticketNonCoffee1 is NULL.");
            }
        }

        private void cuiButton15_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }

        private void btnCoffee_Click(object sender, EventArgs e)
        {
            CoffeePanel.Visible = true;
            FoodPanel.Visible = false;
            AllPanel.Visible = false;
            NonCoffeePanel.Visible = false;

            // ✅ If you want to use the new event-driven approach, uncomment this:
            // ShowTicketCoffee();
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            AllPanel.Visible = true;
            CoffeePanel.Visible = false;
            FoodPanel.Visible = false;
            NonCoffeePanel.Visible = false;
        }

        private void btnAmericano_DoubleClick(object sender, EventArgs e)
        {

        }

        private void cuiButton18_Click(object sender, EventArgs e)
        {

        }

        private void cuiPanel17_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void cuiLabel1_Load(object sender, EventArgs e)
        {

        }

        private void btnCoffee_Click_1(object sender, EventArgs e)
        {
            //panelMain.Controls.Clear();

            //TicketCoffee coffeeControl = new TicketCoffee();
            //coffeeControl.AutoScroll = true; // allow scroll if content exceeds visible area
            //coffeeControl.Dock = DockStyle.Fill; // <-- Remove this
            //coffeeControl.Anchor = AnchorStyles.Top | AnchorStyles.Left; // optional

            //panelMain.Controls.Add(coffeeControl);

            NavigateToTicketCoffee?.Invoke();
        }

        private void btnAmericano_Click_1(object sender, EventArgs e)
        {
            HandleProductSelection("Americano");
        }

        private void btnNonCoffee_Click(object sender, EventArgs e)
        {
            NonCoffeePanel.Visible = true;
            FoodPanel.Visible = false;
            CoffeePanel.Visible = false;
            AllPanel.Visible = false;

            // ✅ If you want to use the new event-driven approach, uncomment this:
            // ShowTicketNonCoffee();
        }

        private void cuiButton24_Click(object sender, EventArgs e)
        {
            PopUpSplitComponent splitForm = new PopUpSplitComponent(this);
            splitForm.StartPosition = FormStartPosition.CenterParent; // Center it over parent form

            if (splitForm.ShowDialog(this) == DialogResult.OK)
            {
                
            }
        }

        private void cuiButton25_Click(object sender, EventArgs e)
        {
            ProcessPayment("Cash", cashReceived, 0, 0);
        }

        private void btnCafeLatte_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Cafe Latte");
        }

        private void cuiButton2_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Caramel Macchiato");
        }

        private void cuiButton3_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Mocha");
        }

        private void cuiButton5_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Cappuccino");
        }

        private void cuiButton17_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
            }
        }

        private void cuiButton16_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;

            }
        }

        private void label32_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton15_Click_1(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
            }
        }

        private void cuiButton14_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
            }
        }

        private void cuiButton13_Click(object sender, EventArgs e)
        {
            var popup = new ProductComponent();
            popup.StartPosition = FormStartPosition.CenterParent;  // Center the popup on the current form

            if (popup.ShowDialog(this) == DialogResult.OK)  // Block parent form until popup is done
            {
                // Access the selected values
                string size = popup.SelectedSize ?? "N/A";
                string type = popup.SelectedType ?? "N/A";
                int qty = popup.Quantity;
            }
        }

        private void cuiButton26_Click(object sender, EventArgs e)
        {
            HandleFoodSelection("Food Item"); // Replace with actual product name
        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton21_Click(object sender, EventArgs e)
        {
            HandleFoodSelection("Food Item"); // Replace with actual product name
        }

        private void cuiButton20_Click(object sender, EventArgs e)
        {
            HandleFoodSelection("Food Item"); // Replace with actual product name
        }

        private void cuiButton19_Click(object sender, EventArgs e)
        {
            HandleFoodSelection("Food Item"); // Replace with actual product name
        }

        private void btnAll_Click_1(object sender, EventArgs e)
        {
            AllPanel.Visible = true;
            CoffeePanel.Visible = false;
            FoodPanel.Visible = false;
            NonCoffeePanel.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDiscount_Click(object sender, EventArgs e)
        {
            pnlChange.Visible = false;
            pnlDiscount.Visible = true;
        }

        private void cuiPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void label39_Click(object sender, EventArgs e)
        {

        }

        private void cuiButton1_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Matcha Latte");
        }

        private void cuiButton4_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Chocolate");
        }

        private void cuiButton18_Click_1(object sender, EventArgs e)
        {
            HandleProductSelection("Strawberry Frappe");
        }

        private void cuiButton27_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Caramel Frappe");
        }

        private void cuiButton28_Click(object sender, EventArgs e)
        {
            HandleProductSelection("Chocolate Chip Frappe");
        }

        private void cuiButton13_Click_1(object sender, EventArgs e)
        {
            HandleFoodSelection("Tocilog");
        }

        private void cuiButton14_Click_1(object sender, EventArgs e)
        {
            HandleFoodSelection("Garlic Rice");
        }

        private void cuiButton15_Click_2(object sender, EventArgs e)
        {
            HandleFoodSelection("Pork Siomai Rice");
        }

        private void cuiButton16_Click_1(object sender, EventArgs e)
        {
            HandleFoodSelection("Hamsilog");
        }

        private void label49_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

 
        private int GetCurrentEmployeeID()
        {
            return SessionManager.CurrentUser.EmployeeID;
        }
        // Centralized method to handle food selection

        private void HandleFoodSelection(string productName)
        {
            // Get ProductID dynamically from database
            int productId = ProductDataAccess.GetProductId(productName);

            if (productId == 0)
            {
                MessageBox.Show($"Product '{productName}' not found in database!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var popup = new FoodQuantity();
            var currentEmployeeID = GetCurrentEmployeeID();
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.ProductId = productId;
            popup.ProductName = productName;

            if (popup.ShowDialog(this) == DialogResult.OK)
            {
                int qty = popup.Quantity;

                // For food items, category is always "Food"
                string category = "Food";

                // For food items, size and type are typically "N/A" or default values
                if (!DeductInventoryForProduct(productId, qty, "N/A", "N/A", category))
                {
                    // Inventory deduction failed, don't add the item
                    return;
                }

                // Product info
                string categoryForItem = "Food";

                // Get prices dynamically
                decimal basePrice = ProductDataAccess.GetBasePrice(productId);
                decimal itemTotal = (basePrice) * qty;

                // Add to cart with proper EmployeeID and all required fields
                currentOrder.Add(new Item
                {
                    EmployeeID = currentEmployeeID,
                    ProductID = productId,
                    ProductName = productName,
                    ProductSize = "N/A",
                    ProductType = "N/A",
                    Extras = new List<string>(),
                    Quantity = qty,
                    Amount = itemTotal,
                    Category = categoryForItem
                });

                AddItemToTicketPanel(currentOrder.Last());
                UpdateSubtotalLabel();
            }
        }

        // Helper method to determine category based on product name
        private string DetermineCategory(string productName)
        {
            // Coffee products
            string[] coffeeProducts = { "Americano", "Cafe Latte", "Caramel Macchiato", "Mocha", "Cappucino" };
            if (coffeeProducts.Contains(productName))
                return "Coffee";

            // Non-coffee products  
            string[] nonCoffeeProducts = { "Matcha Latte", "Chocolate", "Strawberry Frappe", "Caramel Frappe", "Chocolate Chip Frappe" };
            if (nonCoffeeProducts.Contains(productName))
                return "Non Coffee";

            // Default fallback
            return "Other";
        }


        private void AddItemToTicketPanel(Item item)
        {
            Panel panelClone = new Panel
            {
                Size = panelTemplateCartItem.Size,
                BackColor = panelTemplateCartItem.BackColor,
                Margin = panelTemplateCartItem.Margin,
                BorderStyle = panelTemplateCartItem.BorderStyle,
            };

            // Clone labels from the template
            foreach (Control ctrl in panelTemplateCartItem.Controls)
            {
                if (ctrl is Label templateLabel)
                {
                    Label lbl = new Label
                    {
                        AutoSize = templateLabel.AutoSize,
                        Font = templateLabel.Font,
                        ForeColor = templateLabel.ForeColor,
                        Location = templateLabel.Location,
                        Size = templateLabel.Size
                    };

                    switch (templateLabel.Name)
                    {
                        case "lblProductNameTemplate":
                            lbl.Text = item.ProductName;
                            break;
                        case "lblSizeTemplate":
                            lbl.Text = item.ProductSize;
                            break;
                        case "lblTypeTemplate":
                            lbl.Text = item.ProductType;
                            break;
                        case "lblExtrasTemplate":
                            lbl.Text = item.Extras != null && item.Extras.Any() ? string.Join(", ", item.Extras) : "-";
                            break;
                        case "lblQuantityTemplate":
                            lbl.Text = $"x{item.Quantity}";
                            break;
                        case "lblPriceTemplate":
                            lbl.Text = $"₱{item.Amount:0.00}";
                            break;
                        default:
                            lbl.Text = templateLabel.Text;
                            break;
                    }

                    panelClone.Controls.Add(lbl);
                }
            }

            flowTicketPanel.Controls.Add(panelClone);
        }

        private void UpdateSubtotalLabel()
        {
            decimal subtotal = currentOrder.Sum(x => x.Amount);
            decimal finalTotal = subtotal - currentDiscountAmount;
            finalTotal = Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);

            labelSubtotal.Visible = true;
            labelSubtotal.Text = $"₱{finalTotal:0.00}";
        }

        private void btnMoney_Click(object sender, EventArgs e)
        {
            if (sender is Control btn && btn.Tag != null)
            {
                if (decimal.TryParse(btn.Tag.ToString(), out decimal value))
                {
                    cashReceived += value;

                    // Get the latest total amount after discount
                    decimal totalAmount = currentOrder.FirstOrDefault(x => x.Amount > 0)?.Amount ?? 0;
                    totalAmount = Math.Round(totalAmount, 2, MidpointRounding.AwayFromZero);

                    decimal finalTotal = totalAmount - currentDiscountAmount;
                    finalTotal = Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);

                    UpdateCashAndChangeUI(finalTotal); // ✅ Now passes the real total
                }
            }
        }

        private void txtManualAmount_KeyUp(object sender, KeyEventArgs e)
        {
            string input = txtManualAmount.Text.Replace("₱", "").Trim();

            if (decimal.TryParse(input, out decimal value))
            {
                txtManualAmount.TextChanged -= txtManualAmount_TextChanged; // Temporarily unhook
                txtManualAmount.Text = $"₱{value}";
                txtManualAmount.SelectionStart = txtManualAmount.Text.Length;
                txtManualAmount.TextChanged += txtManualAmount_TextChanged;

                cashReceived = value;
                UpdateCashAndChangeUI(GetFinalTotal());
            }
        }

        private void btnClearPayment_Click(object sender, EventArgs e)
        {
            cashReceived = 0;
            UpdateCashAndChangeUI(GetFinalTotal());
            if (txtManualAmount != null) txtManualAmount.Text = "";
        }

        private void UpdateCashAndChangeUI(decimal finalTotal)
        {
            labelCashReceived.Text = $"₱{cashReceived:0.00}";

            decimal change = cashReceived - finalTotal;
            change = Math.Round(change, 2, MidpointRounding.AwayFromZero);

            labelChange.Text = $"₱{(change >= 0 ? change : 0):0.00}";
        }

        private void txtManualAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            pnlChange.Visible = true;
            pnlDiscount.Visible = false;
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            AllPanel.Visible = true;
            CoffeePanel.Visible = false;
            NonCoffeePanel.Visible = false;
            FoodPanel.Visible = false;
            pnlDiscount.Visible = false;
            pnlChange.Visible = true;
            SetupComponents(); // Setup components and wire events
            // Make sure you're referencing the correct control placed on the form
            discountButton2.DiscountClicked += percent => ApplyDiscount(discountRate: percent);

            discountButton2.PesoDiscountEntered += amount =>
            {
                ApplyDiscount(discountAmount: amount);
            };

            discountButton2.PercentDiscountEntered += percent =>
            {
                ApplyDiscount(discountRate: percent);
            };

            discountButton2.DiscountCleared += () =>
            {
                currentDiscountAmount = 0;
                currentDiscountRate = 0;
                UpdateSubtotalLabel();
                UpdateCashAndChangeUI(GetFinalTotal());
            };

            transactionNo = TicketPaymentBackend.GetNextTransactionNo(); // this sets a fresh TransactionNo
        }

        private void ApplyDiscount(decimal discountRate = 0, decimal discountAmount = 0)
        {
            decimal subtotal = currentOrder.Sum(item => item.Amount);
            subtotal = Math.Round(subtotal, 2, MidpointRounding.AwayFromZero);

            if (discountAmount > 0)
            {
                currentDiscountAmount = Math.Round(discountAmount, 2, MidpointRounding.AwayFromZero);
                currentDiscountRate = 0;
            }
            else if (discountRate > 0)
            {
                currentDiscountRate = discountRate;
                currentDiscountAmount = Math.Round(subtotal * (discountRate / 100), 2, MidpointRounding.AwayFromZero);
            }
            else
            {
                currentDiscountAmount = 0;
                currentDiscountRate = 0;
            }

            decimal finalTotal = subtotal - currentDiscountAmount;
            finalTotal = Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);

            // Show original subtotal, not the discounted amount
            labelSubtotal.Text = $"₱{subtotal:0.00}";

            // Pass the discounted final total for change calculation
            UpdateCashAndChangeUI(finalTotal);
        }
        public decimal GetFinalTotal()
        {
            decimal subtotal = currentOrder.Sum(x => x.Amount);
            decimal finalTotal = subtotal - currentDiscountAmount;
            return Math.Round(finalTotal, 2, MidpointRounding.AwayFromZero);
        }

        //Maya and Gcash payment methods
        private void cuiButton23_Click(object sender, EventArgs e)
        {
            decimal finalAmount = GetFinalTotal();
            ProcessPayment("Maya", 0, 0, finalAmount); 
        }

        private void cuiButton22_Click(object sender, EventArgs e)
        {
            decimal finalAmount = GetFinalTotal();
            ProcessPayment("GCash", 0, finalAmount, 0);

        }
        private void ResetTransaction()
        {
            // Clear current order
            currentOrder.Clear();

            // Clear UI
            flowTicketPanel.Controls.Clear();

            // Reset amounts
            cashReceived = 0;
            currentDiscountAmount = 0;
            currentDiscountRate = 0;

            // Reset labels
            labelSubtotal.Text = "₱0.00";
            labelCashReceived.Text = "₱0.00";
            labelChange.Text = "₱0.00";

            // Clear manual amount input
            if (txtManualAmount != null)
                txtManualAmount.Text = "";

            // Get new transaction number for next transaction
            transactionNo = TicketPaymentBackend.GetNextTransactionNo();

            // Reset panels
            pnlChange.Visible = true;
            pnlDiscount.Visible = false;
        }
        public void FinalizeSplitPayment(List<(string Method, decimal Amount)> payments)
        {
            try
            {
                if (currentOrder == null || currentOrder.Count == 0)
                {
                    MessageBox.Show("No items in the order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                decimal cash = 0, gcash = 0, maya = 0;

                foreach (var payment in payments)
                {
                    switch (payment.Method.ToUpper())
                    {
                        case "CASH": cash += payment.Amount; break;
                        case "GCASH": gcash += payment.Amount; break;
                        case "MAYA": maya += payment.Amount; break;
                    }
                }

                ProcessPayment("Split", cash, gcash, maya);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing split payment: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ProcessPayment(string paymentMethod, decimal cashAmount, decimal gcashAmount, decimal mayaAmount)
        {
            try
            {
                // Validate that we have items in the order
                if (currentOrder == null || currentOrder.Count == 0)
                {
                    MessageBox.Show("No items in the order!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate amounts
                decimal subtotal = currentOrder.Sum(x => x.Amount);
                decimal totalAmount = subtotal - currentDiscountAmount;
                decimal paymentAmount = cashAmount + gcashAmount + mayaAmount;
                decimal change = paymentAmount - totalAmount;

                // Validate sufficient payment
                if (change < 0)
                {
                    MessageBox.Show("Insufficient payment amount!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // For pure digital payments (no cash), change should be 0
                // For split payments or cash payments, calculate change normally
                if (paymentMethod != "Cash" && paymentMethod != "Split" && cashAmount == 0)
                {
                    change = 0;
                }

                // Determine discount type
                string discountType = "None";
                if (currentDiscountAmount > 0)
                {
                    discountType = currentDiscountRate > 0 ? "Percentage" : "Fixed Amount";
                }

                // Validate payment data
                if (!TicketPaymentBackend.ValidatePaymentData(totalAmount, paymentAmount, cashAmount, gcashAmount, mayaAmount))
                {
                    return;
                }

                // Save the payment
                TicketPaymentBackend.SavePayment(
                    transactionNo: transactionNo,
                    orderItems: currentOrder,
                    subtotal: subtotal,
                    discountAmount: currentDiscountAmount,
                    discountType: discountType,
                    discountRate: currentDiscountRate,
                    cashAmount: cashAmount,
                    gcashAmount: gcashAmount,
                    mayaAmount: mayaAmount,
                    totalAmount: totalAmount,
                    paymentAmount: paymentAmount,
                    change: change
                );

                // Show receipt
                ShowReceipt(transactionNo);

                // Reset for next transaction
                ResetTransaction();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing payment: {ex.Message}", "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowReceipt(int transactionNo)
        {
            ReceiptForm receipt = new ReceiptForm(transactionNo);
            receipt.ShowDialog();
        }

        private void btnFood_Click_1(object sender, EventArgs e)
        {

        }

        private void cuiSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void panelTemplateCartItem_Paint(object sender, PaintEventArgs e)
        {
            // This is just to ensure the template panel is not empty
        }

        private void lblProductNameTemplate_Click(object sender, EventArgs e)
        {

        }

        private void ticketFood1_Load(object sender, EventArgs e) 
        {

        }

        private void flowTicketPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }
    }
}
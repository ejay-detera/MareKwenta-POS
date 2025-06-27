using System;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

public class MarePosDbCreator
{
    private readonly string server;
    private readonly string userId;
    private readonly string password;
    private readonly int port;
    private readonly string databaseName = "marepos-db"; // Keep original name

    public MarePosDbCreator(string server, string userId, string password, int port = 3306)
    {
        this.server = server;
        this.userId = userId;
        this.password = password;
        this.port = port;
    }

    private string GetServerConnectionString()
    {
        return $"Server={server};Port={port};Uid={userId};Pwd={password};CharSet=utf8mb4;ConnectionTimeout=30;";
    }

    private string GetDatabaseConnectionString()
    {
        return $"Server={server};Port={port};Database={databaseName};Uid={userId};Pwd={password};CharSet=utf8mb4;ConnectionTimeout=30;";
    }

    public async Task<bool> CreateDatabaseAndTablesAsync()
    {
        try
        {
            Console.WriteLine("Starting database creation process...");

            // Test connection first
            if (!await TestConnectionAsync())
            {
                Console.WriteLine("Failed to connect to MySQL server.");
                return false;
            }

            // Create the database
            if (!await CreateDatabaseAsync())
            {
                Console.WriteLine("Failed to create database.");
                return false;
            }

            // Create all tables
            if (!await CreateAllTablesAsync())
            {
                Console.WriteLine("Failed to create tables.");
                return false;
            }

            Console.WriteLine("Database and tables created successfully!");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in CreateDatabaseAndTablesAsync: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
            return false;
        }
    }

    private async Task<bool> TestConnectionAsync()
    {
        try
        {
            Console.WriteLine("Testing MySQL connection...");
            using var connection = new MySqlConnection(GetServerConnectionString());
            await connection.OpenAsync();
            Console.WriteLine("✓ Successfully connected to MySQL server!");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Connection test failed: {ex.Message}");
            return false;
        }
    }

    private async Task<bool> CreateDatabaseAsync()
    {
        try
        {
            Console.WriteLine($"Creating database '{databaseName}'...");

            using var connection = new MySqlConnection(GetServerConnectionString());
            await connection.OpenAsync();

            // Drop database if exists (optional - remove if you want to keep existing data)
            string dropDbQuery = $"DROP DATABASE IF EXISTS `{databaseName}`;";
            using (var dropCommand = new MySqlCommand(dropDbQuery, connection))
            {
                await dropCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"✓ Dropped existing database '{databaseName}' if it existed");
            }

            // Create database
            string createDbQuery = $@"
                CREATE DATABASE `{databaseName}` 
                CHARACTER SET utf8mb4 
                COLLATE utf8mb4_general_ci;";

            using (var createCommand = new MySqlCommand(createDbQuery, connection))
            {
                await createCommand.ExecuteNonQueryAsync();
                Console.WriteLine($"✓ Database '{databaseName}' created successfully!");
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error creating database: {ex.Message}");
            return false;
        }
    }

    private async Task<bool> CreateAllTablesAsync()
    {
        try
        {
            Console.WriteLine("Creating tables...");

            using var connection = new MySqlConnection(GetDatabaseConnectionString());
            await connection.OpenAsync();

            var tables = new[]
            {
                ("employees", GetEmployeesTableQuery()),
                ("expense", GetExpenseTableQuery()),
                ("inventory", GetInventoryTableQuery()),
                ("product", GetProductTableQuery()),
                ("productingredient", GetProductIngredientTableQuery()),
                ("ticket", GetTicketTableQuery()),
                ("timelog", GetTimeLogTableQuery())
            };

            foreach (var (tableName, query) in tables)
            {
                try
                {
                    using var command = new MySqlCommand(query, connection);
                    await command.ExecuteNonQueryAsync();
                    Console.WriteLine($"✓ Table '{tableName}' created successfully!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"✗ Error creating table '{tableName}': {ex.Message}");
                    return false;
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"✗ Error in CreateAllTablesAsync: {ex.Message}");
            return false;
        }
    }

    private string GetEmployeesTableQuery()
    {
        return @"
            CREATE TABLE `employees` (
                `EmployeeID` INT NOT NULL AUTO_INCREMENT,
                `LastName` TEXT NOT NULL,
                `FirstName` TEXT NOT NULL,
                `MiddleName` TEXT NULL,
                `Role` TEXT NOT NULL,
                `Password` TEXT NOT NULL,
                `Username` TEXT NOT NULL,
                `OwnerID` INT NULL,
                PRIMARY KEY (`EmployeeID`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }

    private string GetExpenseTableQuery()
    {
        return @"
            CREATE TABLE `expense` (
                `ExpenseID` INT NOT NULL AUTO_INCREMENT,
                `ExpenseName` VARCHAR(255) NOT NULL,
                `ExpenseAmount` DECIMAL(65,2) NOT NULL,
                `Category` VARCHAR(255) NOT NULL,
                `Date` DATE NOT NULL,
                PRIMARY KEY (`ExpenseID`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }

    private string GetInventoryTableQuery()
    {
        return @"
            CREATE TABLE `inventory` (
                `InventoryID` INT NOT NULL AUTO_INCREMENT,
                `IngredientName` TEXT NOT NULL,
                `Quantity` DECIMAL(65,2) NOT NULL,
                `IngredientCost` DECIMAL(65,2) NOT NULL,
                `IngredientMeasurement` VARCHAR(10) NOT NULL,
                PRIMARY KEY (`InventoryID`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }

    private string GetProductTableQuery()
    {
        return @"
            CREATE TABLE `product` (
                `ProductID` INT NOT NULL AUTO_INCREMENT,
                `ProductName` VARCHAR(255) NULL,
                `UnitPrice` DECIMAL(65,2) NULL,
                `SellingPrice` DECIMAL(65,2) NULL,
                `GrandeHotPrice` DECIMAL(65,2) NULL,
                `GrandeIcedPrice` DECIMAL(65,2) NULL,
                `VentiHotPrice` DECIMAL(65,2) NULL,
                `VentiIcedPrice` DECIMAL(65,2) NULL,
                PRIMARY KEY (`ProductID`)
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }

    private string GetProductIngredientTableQuery()
    {
        return @"
            CREATE TABLE `productingredient` (
                `ProductIngredientID` INT NOT NULL AUTO_INCREMENT,
                `ProductID` INT NULL,
                `InventoryID` INT NULL,
                `Quantity` DECIMAL(65,2) NULL,
                `Category` TEXT NOT NULL,
                PRIMARY KEY (`ProductIngredientID`),
                INDEX `FK_ProductIngredient_Product` (`ProductID`),
                INDEX `FK_ProductIngredient_Inventory` (`InventoryID`),
                CONSTRAINT `FK_ProductIngredient_Product` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`) ON DELETE SET NULL,
                CONSTRAINT `FK_ProductIngredient_Inventory` FOREIGN KEY (`InventoryID`) REFERENCES `inventory` (`InventoryID`) ON DELETE SET NULL
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }

    private string GetTicketTableQuery()
    {
        return @"
            CREATE TABLE `ticket` (
                `TicketID` INT NOT NULL AUTO_INCREMENT,
                `EmployeeID` INT NULL,
                `ProductID` INT NULL,
                `ProductQuantity` DECIMAL(65,2) NULL,
                `TotalAmount` DECIMAL(65,2) NULL,
                `PaymentAmount` DECIMAL(65,2) NULL,
                `Change` DECIMAL(65,2) NULL,
                `DiscountRate` DECIMAL(65,2) NULL,
                `PaymentType` TEXT NULL,
                `DiscountType` TEXT NULL,
                `Date` DATETIME NULL,
                `Category` TEXT NULL,
                `TransactionNo` INT NULL,
                `GCashAmount` DECIMAL(65,2) NULL,
                `MayaAmount` DECIMAL(65,2) NULL,
                `Subtotal` DECIMAL(65,2) NULL,
                `Size` TEXT NULL,
                `Type` TEXT NULL,
                `CashAmount` DECIMAL(65,2) NULL,
                PRIMARY KEY (`TicketID`),
                INDEX `FK_Ticket_Employee` (`EmployeeID`),
                INDEX `FK_Ticket_Product` (`ProductID`),
                CONSTRAINT `FK_Ticket_Employee` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE SET NULL,
                CONSTRAINT `FK_Ticket_Product` FOREIGN KEY (`ProductID`) REFERENCES `product` (`ProductID`) ON DELETE SET NULL
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }

    private string GetTimeLogTableQuery()
    {
        return @"
            CREATE TABLE `timelog` (
                `TimeLogID` INT NOT NULL AUTO_INCREMENT,
                `EmployeeID` INT NOT NULL,
                `Date` DATE NULL,
                `TimeIn` TIME NULL,
                `TimeOut` TIME NULL,
                `CreatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
                `UpdatedAt` TIMESTAMP DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
                PRIMARY KEY (`TimeLogID`),
                INDEX `FK_TimeLog_Employee` (`EmployeeID`),
                CONSTRAINT `FK_TimeLog_Employee` FOREIGN KEY (`EmployeeID`) REFERENCES `employees` (`EmployeeID`) ON DELETE CASCADE
            ) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;";
    }
}
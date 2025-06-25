using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mare_POS.Ticket_Dashboard
{
    public partial class ProductComponent : Component
    {
        public ProductComponent()
        {
            InitializeComponent();
        }

        public ProductComponent(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}

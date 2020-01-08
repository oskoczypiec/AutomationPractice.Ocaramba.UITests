using Ocaramba;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderPage : ProjectPageBase
    {
        private readonly ElementLocator
            orderItemName = new ElementLocator(Locator.CssSelector, "tr >.cart_description > p > a"),
            orderIdName = new ElementLocator(Locator.CssSelector, ""),
            orderAddQty = new ElementLocator(Locator.CssSelector, "");

        public OrderPage(DriverContext driverContext) : base(driverContext)
        {

        }

        public void ChangeQty(string itemName, int qty)
        {
           
        }
    }
}

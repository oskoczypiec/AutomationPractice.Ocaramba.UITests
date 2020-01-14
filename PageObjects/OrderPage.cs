using Ocaramba;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderPage : ProjectPageBase
    {
        static string itemName = string.Empty;
        private readonly ElementLocator
            orderItemName = new ElementLocator(Locator.CssSelector, $"//*[@class='product-name']//*[@class='cart_block_product_name']/@title[.='{itemName}']"),
            orderIdName = new ElementLocator(Locator.CssSelector, ""),
            orderAddQty = new ElementLocator(Locator.CssSelector, "");

        public OrderPage(DriverContext driverContext) : base(driverContext)
        {

        }
        public void CheckOrderItems(string[] expectedItems)
        {   
            //var actualItems = //getElements
          //  Assert.That(item.Contains(linq)

            // Assert.That()
        }

        public void ChangeQty(string itemName, int qty)
        {
           
        }


    }
}

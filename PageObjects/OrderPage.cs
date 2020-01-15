using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderPage : ProjectPageBase
    {
        static string itemName = string.Empty;
        private readonly ElementLocator
            orderItem = new ElementLocator(Locator.CssSelector, $"//*[@class='product-name']//*[@class='cart_block_product_name']/@title[.='{itemName}']"),
            orderAllItems = new ElementLocator(Locator.XPath, "//*[@class='cart_description']//*[@class='product-name']/a"),
            orderIdName = new ElementLocator(Locator.CssSelector, ""),
            orderAddQty = new ElementLocator(Locator.CssSelector, "");

        public OrderPage(DriverContext driverContext) : base(driverContext)
        {

        }
        public void CheckOrderItems(params string[] expectedOrderItems)
        {
            IList<IWebElement> orderItems = Driver.GetElements(orderAllItems);
            List<string> actualOrderItems = new List<string>();

            actualOrderItems.AddRange(orderItems.Select(x => x.Text));

            Assert.That(expectedOrderItems, Is.EqualTo(actualOrderItems));
        }

        public void ChangeQty(string itemName, int qty)
        {
           
        }


    }
}

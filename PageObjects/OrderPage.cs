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
        private readonly ElementLocator
            orderAllItems = new ElementLocator(Locator.XPath, "//*[@class='cart_description']//*[@class='product-name']/a");

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

        public void ChangeQty(string name, int qty)
        {
            for (int i = 1; i < qty; i++)
            {
                Driver.GetElement(ItemAddQty(name)).Click();
            }
        }

        private ElementLocator ItemAddQty(string item)
        {
            return new ElementLocator(Locator.XPath, $"//p[@class='product-name']/a[.='{item}']/../../..//a[@title='Add']");
        }


    }
}

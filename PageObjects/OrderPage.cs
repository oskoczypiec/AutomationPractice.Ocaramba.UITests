using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;


namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderPage : ProjectPageBase
    {
        private readonly ElementLocator
            orderAllItems = new ElementLocator(Locator.XPath, "//*[@class='cart_description']//*[@class='product-name']/a"),
            addressName = new ElementLocator(Locator.CssSelector, "ul.first_item > li > .address_name"),
            addressAddress1 = new ElementLocator(Locator.CssSelector, "ul.first_item > li > .address_address1"),
            addressCity = new ElementLocator(Locator.CssSelector, "ul.first_item > li > .address_city"),
            addressPhoneMobile = new ElementLocator(Locator.CssSelector, "ul.first_item >li > .address_phone_mobile"),
            addressCountry = new ElementLocator(Locator.XPath, "//*[@class='address first_item item box']/li[5]/span"),
            invoiceName = new ElementLocator(Locator.CssSelector, "ul.last_item > li > .address_name"),
            invoiceAddress1 = new ElementLocator(Locator.CssSelector, "ul.last_item > li > .address_address1"),
            invoiceCity = new ElementLocator(Locator.CssSelector, "ul.last_item > li > .address_city"),
            invoiceCountry = new ElementLocator(Locator.XPath, "//*[@class='address last_item alternate_item box']/li[5]/span"),
            invoicePhoneMobile = new ElementLocator(Locator.CssSelector, "ul.last_item > li > .address_phone_mobile"),
            proceedToCheckoutButton = new ElementLocator(Locator.CssSelector, ".standard-checkout");


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
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        public void CheckTotalPrice(string expectedTotalPrice)
        {
            var actualTotalPrice = Driver.GetElement(CurrentTotalPrice).Text.Trim('$');
            Assert.That(actualTotalPrice, Is.EqualTo(expectedTotalPrice));
        }

        public ElementLocator CurrentTotalPrice => new ElementLocator(Locator.Id, "total_price");

        public void CheckDeliveryAddress(params string[] expectedDeliveryAddress)
        {
            var name = Driver.GetElement(addressName).Text;
            var address = Driver.GetElement(addressAddress1).Text;
            var city = Driver.GetElement(addressCity).Text;
            var number = Driver.GetElement(addressPhoneMobile).Text;
            var country = Driver.GetElement(addressCountry).Text;

            List<string> actualDeliveryAddress = new List<string> { name, address, city, country, number };

            Assert.AreEqual(expectedDeliveryAddress, actualDeliveryAddress);
        }

        public void CheckInvoiceAddress(params string[] expectedInvoiceAddress)
        {
            var name = Driver.GetElement(invoiceName).Text;
            var address = Driver.GetElement(invoiceAddress1).Text;
            var city = Driver.GetElement(invoiceCity).Text;
            var number = Driver.GetElement(invoicePhoneMobile).Text;
            var country = Driver.GetElement(invoiceCountry).Text;

            List<string> actualInvoiceAddress = new List<string> { name, address, city, country, number };

            Assert.AreEqual(expectedInvoiceAddress, actualInvoiceAddress);
        }

        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutButton).Click();
        }

        private ElementLocator ItemAddQty(string item)
        {
            return new ElementLocator(Locator.XPath, $"//p[@class='product-name']/a[.='{item}']/../../..//a[@title='Add']");
        }


    }
}

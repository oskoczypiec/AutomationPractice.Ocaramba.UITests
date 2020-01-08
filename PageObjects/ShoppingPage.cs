using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class ShoppingPage : ProjectPageBase
    {
        public readonly ElementLocator
            womenCategoryPage = new ElementLocator(Locator.CssSelector, ".sf-menu > li:nth-child(1)"),
            dressesCategoryChecker = new ElementLocator(Locator.CssSelector, "#center_column > #subcategories > .clearfix > li:nth-child(2)"),
            dressItem = new ElementLocator(Locator.CssSelector, ".product_list > li:nth-child(1)"),
            addToCartButton = new ElementLocator(Locator.Id, "add_to_cart"),
            layerCartTitle = new ElementLocator(Locator.CssSelector, ".layer_cart_product > h2:nth-child(2)"),
            proceedCheckoutButton = new ElementLocator(Locator.CssSelector, "a.btn:nth-child(2)"),
            standardCheckoutButton = new ElementLocator(Locator.CssSelector, ".standard-checkout"),
            itemPrice = new ElementLocator(Locator.CssSelector, "td > span> .price"),
            deliveryName = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_firstname"),
            deliveryStreet1 = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_address1"),
            deliveryStreet2 = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_address2"),
            deliveryCity = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_city"),
            deliveryState = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_state_name"),
            deliveryPostCode = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_postcode"),
            deliveryCountryName = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_country_name"),
            deliveryPhoneNumber = new ElementLocator(Locator.CssSelector, "#address_delivery > .address_phone_mobile"),
            addressProceedCheckout = new ElementLocator(Locator.CssSelector, ".cart_navigation .button-medium");
            

        public ShoppingPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void GoToHomePage()
        {
            DriverContext.Driver.NavigateTo(new System.Uri("http://automationpractice.com"));
        }

        public void GoToCategory(string categoryName)
        {
            Driver.GetElement(new ElementLocator(Locator.CssSelector, $".sf-menu > li > a[title='{categoryName}']")).Click();
        }

        public void SelectItem(string itemName)
        {
            Driver.GetElement(new ElementLocator(Locator.CssSelector, $".product-name[title='{itemName}'")).Click();
        }

        public string AddItemToCart(string categoryName, string itemName)
        {
            GoToCategory(categoryName);
            SelectItem(itemName);
            var itemPrice = DriverContext.Driver.FindElement(By.Id("our_price_display")).Text;
            Driver.GetElement(addToCartButton).Click();
            return itemPrice;
        }

        public string SummaryOrder()
        {
            Driver.GetElement(proceedCheckoutButton).Click();
            return Driver.GetElement(itemPrice).Text; 

        }
        public List <string> DeliveryAddress()
        {
            Driver.GetElement(standardCheckoutButton).Click();

            var name = Driver.GetElement(deliveryName).Text;
            var streetAddress = Driver.GetElement(deliveryStreet1).Text;
            var cityStatePostCode = Driver.GetElement(deliveryCity).Text;
            var state = Driver.GetElement(deliveryState).Text;
            var postCode = Driver.GetElement(deliveryPostCode).Text;
            var country = Driver.GetElement(deliveryCountryName).Text;
            var phoneNumber = Driver.GetElement(deliveryPhoneNumber).Text;

            List<string> getDeliveryAddressDetails;
            getDeliveryAddressDetails = new List<string> {name, streetAddress, cityStatePostCode, country, phoneNumber };

            return getDeliveryAddressDetails;
        }

        public void DeliveryMethod()
        {
            Driver.GetElement(addressProceedCheckout).Click();

        }

        public void PaymentMethod()
        {

        }


    }
}

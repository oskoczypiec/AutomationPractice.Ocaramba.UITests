using Ocaramba;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Ocaramba.Extensions;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class CategoryPage : ProjectPageBase
    {
        public readonly ElementLocator
            addToCartButton = new ElementLocator(Locator.Id, "add_to_cart"),
            continueShoppingButton = new ElementLocator(Locator.CssSelector, ".continue > span:nth-child(1)"),
            proceedCheckoutButton = new ElementLocator(Locator.CssSelector, "a.button-medium > span:nth-child(1)");


        public CategoryPage(DriverContext driverContext) : base(driverContext)
        {

        }
        public void GoToCategory(string categoryName)
        {
            Driver.GetElement(new ElementLocator(Locator.CssSelector, $".sf-menu > li > a[title='{categoryName}']")).Click();
        }

        public void SelectItem(string itemName)
        {
            Driver.GetElement(new ElementLocator(Locator.CssSelector, $".product-name[title='{itemName}'")).Click();
        }

        public void AddToCart(string itemName)
        {
            SelectItem(itemName);
            Driver.GetElement(addToCartButton).Click();
        
        }
        public void ClickContinueShopping()
        {
            Driver.GetElement(continueShoppingButton).Click();
        }

        public void ClickProceedToCheckout()
        {
            Driver.GetElement(continueShoppingButton).Click();
        }
    }
}

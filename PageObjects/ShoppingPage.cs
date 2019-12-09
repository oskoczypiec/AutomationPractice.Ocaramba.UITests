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
            standardCheckoutButton = new ElementLocator(Locator.CssSelector, ".standard-checkout");

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

        public void AddItemToCart(string categoryName, string itemName)
        {
            GoToCategory(categoryName);
            SelectItem(itemName);
            Driver.GetElement(addToCartButton).Click();
            Driver.GetElement(proceedCheckoutButton).Click();
        }
        public void BuyItem()
        {
            Driver.GetElement(standardCheckoutButton).Click();
        }
    }
}

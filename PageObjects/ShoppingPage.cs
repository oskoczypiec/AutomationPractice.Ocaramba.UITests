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
            layerCartTitle = new ElementLocator(Locator.CssSelector, ".layer_cart_product > h2:nth-child(2)");

        public ShoppingPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void AddItemToCard()
        {
            Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");
            Driver.GetElement(womenCategoryPage).Click();
            Driver.GetElement(dressesCategoryChecker).Click();
            Driver.GetElement(dressItem).Click();
            Driver.GetElement(addToCartButton).Click();
        }
    }
}

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
        private readonly ElementLocator
            womenCategoryPage = new ElementLocator(Locator.CssSelector, ".sf-menu > li:nth-child(1)"),
            topsCategoryChecker = new ElementLocator(Locator.CssSelector, "#center_column > #subcategories > .clearfix > li:nth-child(2)"),
            dressItem = new ElementLocator(Locator.CssSelector, ".product_list > li:nth-child(1)"),
            addToCart = new ElementLocator(Locator.CssSelector, ".exclusive");
        public ShoppingPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void BuyItem()
        {
            Driver.FindElement(By.CssSelector(womenCategoryPage.Value));

        }
    }
}

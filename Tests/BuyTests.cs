using NUnit.Framework;
using AutomationPractice.Ocaramba.UITests.PageObjects;
using Ocaramba.Extensions;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

namespace AutomationPractice.Ocaramba.UITests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class BuyTests : ProjectTestBase
    {
        [Test]
        public void AddToCart()
        {
            var shoppingPage = new ShoppingPage(this.DriverContext);
            var expectedTitle = "Product successfully added to your shopping cart";
            shoppingPage.AddItemToCard();
            IWebElement unformattedCartTitle = DriverContext.Driver.FindElement(By.CssSelector(".layer_cart_product > h2:nth-child(2)"));
            var actualTitle = Regex.Replace(unformattedCartTitle.GetTextContent(), @"\r+\n+\t+", "");

            Assert.That(actualTitle, Is.EqualTo(expectedTitle));

        }
    }
}

using NUnit.Framework;
using AutomationPractice.Ocaramba.UITests.PageObjects;
using Ocaramba.Extensions;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using Ocaramba;
using Ocaramba.Types;

namespace AutomationPractice.Ocaramba.UITests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class BuyTests : ProjectTestBase
    {
        ShoppingPage instance;
        HomePage user;
        [SetUp]
        public void Setup()
        {
            user = new HomePage(this.DriverContext);
            user.Login("o.skoczypiec@gmail.com", "testing123");
            instance = new ShoppingPage(this.DriverContext);
            instance.GoToHomePage();
        }

        [TearDown]
        public void TearDown()
        {
            user.Logout();
        }

        [Test]
        public void CheckIfCategoryIsOpened()
        {
            instance.GoToCategory("Women");
            var expectedCategoryOpened = DriverContext.Driver.FindElement(By.CssSelector(".cat-name")).Text.Trim();
            StringAssert.AreEqualIgnoringCase("Women", expectedCategoryOpened);
        }

        [Test]
        public void CheckIfItemIsOpened()
        { 
            instance.SelectItem("Blouse");
            var expectedItemSelected = DriverContext.Driver.FindElement(By.CssSelector(".pb-center-column > h1:nth-child(1)")).Text;
            StringAssert.AreEqualIgnoringCase("Blouse", expectedItemSelected);
        }


        [TestCase("Women", "Blouse")]
        [TestCase("Dresses", "Printed Chiffon Dress")]
        [TestCase("T-shirts", "Faded Short Sleeve T-shirts")]
        public void CheckIfItemCanBeBought(string category, string item)
        {
            var shoppingPage = new ShoppingPage(this.DriverContext);
            shoppingPage.AddItemToCart(category, item);
           
        }
    }
}

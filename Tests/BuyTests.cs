using NUnit.Framework;
using AutomationPractice.Ocaramba.UITests.PageObjects;
using Ocaramba.Extensions;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using Ocaramba;
using Ocaramba.Types;
using System.Linq;
using System.Collections.Generic;

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
            DriverContext.WindowMaximize();
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
            var expectedPrice = shoppingPage.AddItemToCart(category, item);
            var actualPrice = shoppingPage.SummaryOrder();
            
            Assert.That(actualPrice, Is.EqualTo(expectedPrice));

            var deliveryAddressDetails = shoppingPage.DeliveryAddress();
            var expectedAddressDetails = new List<string> { "Aleksandra S", "Unicorn Land 6", "Wroclaw, Oregon 56757", "United States", "123456789" };
            Assert.AreEqual(deliveryAddressDetails, expectedAddressDetails);
        }

        [Test]
        public void BuyingItems()
        {
            var loginPage = new LoginPage(DriverContext);
            var homePage = new HomePage(DriverContext);
            var categoryPage = new CategoryPage(DriverContext);
            var orderPage = new OrderPage(DriverContext);
            var orderAddressPage = new OrderAddressPage(DriverContext);
            var orderShippingPage = new OrderShippingPage(DriverContext);
            var orderPaymentPage = new OrderPaymentPage(DriverContext);
            var orderConfirmationPage = new OrderConfirmationPage(DriverContext);

            loginPage.LoginAsUser();
            //loginPage.LoginAsOtherUser("o.skoczypiec@gmail.com", "xxx123");
            //mainPage.CheckIfUserIsLoggedAs("Aleksandra S"); // no checking in page object
            homePage.GoToCategory("Summer Dresses");
            categoryPage.AddToCart("Printed Summer Dress");
            categoryPage.ClickContinueShopping();
            categoryPage.AddToCart("Printed Chiffon Dress");
            categoryPage.ClickProceedToCheckout();
            //orderPage.CheckOrderItems(); no checking in page object 
            orderPage.ChangeQty("Printed Chiffon Dress", 2);
            //orderPage.CheckTotalPrice(); no checking in page object 
            //orderPage.CheckDeliveryAddress(); no checking in page object 
            //orderPage.CheckInvoiceAddress(); no checking in page object 
            //orderPage.ClickProceedToCheckout(); no checking in page object 
            orderAddressPage.ClickProceedToCheckout();
            orderShippingPage.SelectCheckboxTermsOfService();
            orderShippingPage.ClickProceedToCheckout();
            //orderPaymentPage.CheckTotalPrice(); no checking in page object 
            orderPaymentPage.ClickPayByCheck();
            orderPaymentPage.ClickConfirmMyOrder();
            //orderPaymentPage.CheckPaymentAmount(); no checking in page object
            orderConfirmationPage.ClickBackToOrders();
            //orderHistoryPage.CheckTotalPrice(); no checking in page object 
            //orderHistoryPage.CheckPaymentType(); no checking in page object
            homePage.Logout();
        }

    }
}

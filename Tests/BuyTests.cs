using NUnit.Framework;
using AutomationPractice.Ocaramba.UITests.PageObjects;
using Ocaramba;

namespace AutomationPractice.Ocaramba.UITests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class BuyTests : ProjectTestBase
    {

        [SetUp]
        public void Setup()
        {
            DriverContext.WindowMaximize();
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
            homePage.CheckIfUserIsLoggedAs("Aleksandra S"); 
            homePage.GoToCategory("Summer Dresses"); 
            categoryPage.AddToCart("Printed Summer Dress");
            categoryPage.ClickContinueShopping();
            homePage.GoToCategory("Summer Dresses");
            categoryPage.AddToCart("Printed Chiffon Dress");
            categoryPage.ClickProceedToCheckout();
            orderPage.CheckOrderItems("Printed Summer Dress", "Printed Chiffon Dress"); 
            orderPage.ChangeQty("Printed Chiffon Dress", 2);
            orderPage.CheckTotalPrice("63.78");
            orderPage.CheckDeliveryAddress("Aleksandra S", "Unicorn Land 611", "Wroclaw, Oregon 56757", "United States", "123456789");
            orderPage.CheckInvoiceAddress("Aleksandra S", "Unicorn Land 611", "Wroclaw, Oregon 56757", "United States", "123456789");
            orderPage.ClickProceedToCheckout();
            orderAddressPage.ClickProceedToCheckout();
            orderShippingPage.SelectCheckboxTermsOfService();
            orderShippingPage.ClickProceedToCheckout();
            orderPaymentPage.CheckTotalPrice("63.78");
            orderPaymentPage.ClickPayByCheck();
            orderPaymentPage.ClickConfirmMyOrder();
            orderPaymentPage.CheckPaymentAmount("63.78"); 
            orderConfirmationPage.ClickBackToOrders();
            homePage.Logout();
        }
    }
}

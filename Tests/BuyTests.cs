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
            categoryPage.AddToCart("Printed Chiffon Dress");
            categoryPage.ClickProceedToCheckout();
            orderPage.CheckOrderItems(); 
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

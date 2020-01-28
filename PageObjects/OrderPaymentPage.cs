using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderPaymentPage : ProjectPageBase
    {
        private readonly ElementLocator
            payByCheckButton = new ElementLocator(Locator.ClassName, "cheque"),
            confirmOrderButton = new ElementLocator(Locator.CssSelector, "button.button-medium"),
            totalPrice = new ElementLocator(Locator.Id, "total_price"),
            paymentAmount = new ElementLocator(Locator.CssSelector, ".box > span.price");

        public OrderPaymentPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickPayByCheck()
        {
            Driver.GetElement(payByCheckButton).Click();
        }

        public void ClickConfirmMyOrder()
        {
            Driver.GetElement(confirmOrderButton).Click();
        }

        public void CheckTotalPrice(string expectedTotalPrice)
        {
            var actualTotalPrice = Driver.GetElement(totalPrice).Text.Trim('$');
            Assert.That(expectedTotalPrice, Is.EqualTo(actualTotalPrice));
        }

        public void CheckPaymentAmount(string expectedPaymentAmount)
        {
            var actualPaymentAmount = Driver.GetElement(paymentAmount).Text.Trim('$');
            Assert.That(expectedPaymentAmount, Is.EqualTo(actualPaymentAmount));
        }
    }
}

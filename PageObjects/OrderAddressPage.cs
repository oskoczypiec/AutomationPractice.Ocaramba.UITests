using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderAddressPage : ProjectPageBase
    {
        private readonly ElementLocator
            proceedToCheckoutButton = new ElementLocator(Locator.CssSelector, ".button[name='processAddress']");

        public OrderAddressPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutButton).Click();
        }
    }
}

using Ocaramba;
using Ocaramba.Types;
using Ocaramba.Extensions;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderShippingPage : ProjectPageBase
    {
        private readonly ElementLocator
            checkboxTermsOfService = new ElementLocator(Locator.ClassName, "checkbox"),
            proceedToCheckoutButton = new ElementLocator(Locator.CssSelector, "p > button");

        public OrderShippingPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void SelectCheckboxTermsOfService()
        {
            Driver.GetElement(checkboxTermsOfService).Click();
        }
        
        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutButton).Click();
        }
    }
}

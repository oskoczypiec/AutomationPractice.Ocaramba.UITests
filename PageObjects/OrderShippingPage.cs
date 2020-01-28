using Ocaramba;
using Ocaramba.Types;
using Ocaramba.Extensions;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderShippingPage : ProjectPageBase
    {
        private readonly ElementLocator
            checkboxTermsOfService = new ElementLocator(Locator.Id, "uniform-cgv"),
            proceedToCheckoutButton = new ElementLocator(Locator.Name, "processCarrier");

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

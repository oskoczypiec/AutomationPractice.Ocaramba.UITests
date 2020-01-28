using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderConfirmationPage : ProjectPageBase
    {
        private readonly ElementLocator
            backToOrdersButton = new ElementLocator(Locator.ClassName, "button-exclusive");

        public OrderConfirmationPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public void ClickBackToOrders()
        {
            Driver.GetElement(backToOrdersButton).Click();
        }
    }
}

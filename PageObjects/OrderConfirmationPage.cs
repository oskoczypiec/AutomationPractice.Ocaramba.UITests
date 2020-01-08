using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderConfirmationPage : ProjectPageBase
    {
        private readonly ElementLocator
            backToOrdersButton = new ElementLocator(Locator.ClassName, ".button-exclusive");

        public OrderConfirmationPage(DriverContext driverContext) : base(driverContext)
        {

        }

        public void ClickBackToOrders()
        {
            Driver.GetElement(backToOrdersButton).Click();
        }
    }
}

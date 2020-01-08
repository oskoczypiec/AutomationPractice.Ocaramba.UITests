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
    class OrderAddressPage : ProjectPageBase
    {
        private readonly ElementLocator
            proceedToCheckoutButton = new ElementLocator(Locator.CssSelector, ".standard-checkout");

        public OrderAddressPage(DriverContext driverContext) : base(driverContext)
        {

        }
        public void ClickProceedToCheckout()
        {
            Driver.GetElement(proceedToCheckoutButton).Click();
        }
    }
}

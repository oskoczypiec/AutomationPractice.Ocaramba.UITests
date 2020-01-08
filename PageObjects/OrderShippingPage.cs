using Ocaramba;
using Ocaramba.Types;
using Ocaramba.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class OrderShippingPage : ProjectPageBase
    {
        private readonly ElementLocator
            checkboxTermsOfService = new ElementLocator(Locator.Id, "#cgv"),
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

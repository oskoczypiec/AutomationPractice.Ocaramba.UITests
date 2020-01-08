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
    class OrderPaymentPage : ProjectPageBase
    {
        private readonly ElementLocator
            payByCheckButton = new ElementLocator(Locator.ClassName, ".cheque"),
            confirmOrderButton = new ElementLocator(Locator.CssSelector, "button.button-medium");
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
    }
}

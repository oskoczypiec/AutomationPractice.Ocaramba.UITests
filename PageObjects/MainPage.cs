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
    class MainPage : ProjectPageBase
    {
        private readonly ElementLocator
            currentUserName = new ElementLocator(Locator.CssSelector, "#header > div.nav > div > div > nav > div:nth-child(1) > a > span");
     
        public MainPage(DriverContext driverContext) : base(driverContext)
        {

        }
        //span[contains(text(),'Aleksandra S')]




    }
}

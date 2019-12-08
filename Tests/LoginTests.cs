using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationPractice.Ocaramba.UITests.PageObjects;
using NUnit.Framework;

namespace AutomationPractice.Ocaramba.UITests.Tests
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    class LoginTests : ProjectTestBase
    {
        [TestCase("o.skoczypiec@gmail.com", "testing123")]
        public void LogInCorrect(string email, string password)
        {
            var homePage = new HomePage(this.DriverContext);
            homePage.Login(email, password);

            string expectedUrl = "http://automationpractice.com/index.php?controller=my-account";
            string actualUrl = this.DriverContext.Driver.Url;
            Assert.That(actualUrl, Is.EqualTo(expectedUrl));
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NUnit.Framework;
using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    class HomePage : ProjectPageBase
    {
        private static readonly NLog.Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Locators for elements
        /// </summary>
        private readonly ElementLocator 
            emailField = new ElementLocator(Locator.ClassName, "email"),
            passwordField = new ElementLocator(Locator.ClassName, "passwd"),
            loginButton = new ElementLocator(Locator.ClassName, "SubmitLogin"),
            logoutButton = new ElementLocator(Locator.ClassName, "logout"),
            loggedUser= new ElementLocator(Locator.CssSelector, ".account span");

        private readonly By
            subMenuContainer = By.CssSelector("a[title='Women']");

        private readonly string myAccountPage ="http://automationpractice.com/index.php?controller=my-account";
        public HomePage(DriverContext driverContext) : base(driverContext)
        {
        }
       
        public void Login(string email, string password)
        {
            this.Driver.Navigate().GoToUrl(myAccountPage);
            this.Driver.FindElement(By.Id(emailField.Value)).SendKeys(email);
            this.Driver.FindElement(By.Id(passwordField.Value)).SendKeys(password);
            this.Driver.FindElement(By.Id(loginButton.Value)).Click();
        }

        public void Logout() 
        {
            Driver.GetElement(logoutButton).Click();
        }
        public void GoToCategory(string categoryName)
        {

            var getSubMenuContainer = Driver.FindElement(subMenuContainer);
            var category = By.CssSelector($"a[title='{categoryName}']");
            HoverOnElement(getSubMenuContainer);
            Driver.FindElement(category).Click(); //TODO: Not working, menu is hovered not long enough

        }

        private void HoverOnElement(IWebElement element)
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(element).Build();
            action.Perform();
            TimeSpan.FromSeconds(4);
        }

        public void CheckIfUserIsLoggedAs(string expectedLoggedUser)
        {
            var actualLoggerUser = Driver.GetElement(loggedUser).Text;
            Assert.That(expectedLoggedUser, Is.EqualTo(actualLoggerUser));
        }
    }
}

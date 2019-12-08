using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using Ocaramba;
using Ocaramba.Types;
using OpenQA.Selenium;

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
            logoutButton = new ElementLocator(Locator.ClassName, "logout");

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
            Driver.FindElement(By.ClassName(logoutButton.Value)).Click();
        }

    }
}

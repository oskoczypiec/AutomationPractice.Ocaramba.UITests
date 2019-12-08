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
            loginButton = new ElementLocator(Locator.ClassName, "SubmitLogin");
        public HomePage(DriverContext driverContext) : base(driverContext)
        {
        }
       
        public void Login(string email, string password)
        {
            this.Driver.Navigate().GoToUrl("http://automationpractice.com/index.php?controller=my-account");

            this.Driver.FindElement(By.Id(emailField.Value)).SendKeys(email);
            this.Driver.FindElement(By.Id(passwordField.Value)).SendKeys(password);
            this.Driver.FindElement(By.Id(loginButton.Value)).Click();
        }

        
    }
}

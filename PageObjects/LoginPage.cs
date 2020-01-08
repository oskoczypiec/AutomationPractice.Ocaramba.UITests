using Ocaramba;
using Ocaramba.Extensions;
using Ocaramba.Types;

namespace AutomationPractice.Ocaramba.UITests.PageObjects
{
    public class LoginPage : ProjectPageBase
    {
        private readonly ElementLocator
            loginButton = new ElementLocator(Locator.ClassName, "login"),
            emailField = new ElementLocator(Locator.Id, "email"),
            passwordField = new ElementLocator(Locator.Id, "passwd"),
            signInButton = new ElementLocator(Locator.Id, "SubmitLogin");

        public LoginPage(DriverContext driverContext) : base(driverContext)
        {
        }

        public LoginPage LoginAsUser()
        {
            Login(ProjectBaseConfiguration.UsernameUser, ProjectBaseConfiguration.PasswordUser);
            return this;
        }

        public LoginPage LoginAsOtherUser(string email, string password)
        {
            Login(email, password);
            return this;
        }

        private void Login(string email, string password)
        {
            GoToLoginPage();
            this.Driver.GetElement(emailField).SendKeys(email);
            this.Driver.GetElement(passwordField).SendKeys(password);
            this.Driver.GetElement(signInButton).Click();
        }

        public void GoToLoginPage()
        {
            this.Driver.GetElement(loginButton).Click();
        }
    }
}
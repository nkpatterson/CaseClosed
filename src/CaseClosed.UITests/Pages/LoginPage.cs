using System;
using OpenQA.Selenium;

namespace CaseClosed.UITests.Pages
{
    public class LoginPage
    {
        public IWebDriver Driver { get; private set; }
        private By _usernameSelector = By.Id("EmailAddressInput");
        private By _passwordSelector = By.Id("PasswordInput");
        private By _loginSelector = By.Id("LoginButton");

        public LoginPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public HomePage LoginAs(string username, string password)
        {
            Driver.FindElement(_usernameSelector).SendKeys(username);
            Driver.FindElement(_passwordSelector).SendKeys(password);
            Driver.FindElement(_loginSelector).Click();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5); // Hack...

            return new HomePage(Driver);
        }
    }
}
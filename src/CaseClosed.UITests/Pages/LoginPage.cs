using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseClosed.UITests.Pages
{
    public class LoginPage
    {
        public IWebDriver Driver { get; private set; }
        private string _returnUrl;
        private By _usernameLocator = By.Id("cred_userid_inputtext");
        private By _passwordLocator = By.Id("cred_password_inputtext");
        private By _submitLocator = By.Id("cred_sign_in_button");

        public LoginPage(IWebDriver driver, string returnUrl)
        {
            Driver = driver;
            _returnUrl = returnUrl;

            Driver.Navigate().GoToUrl(_returnUrl);

            Assert.IsTrue(Driver.Title.StartsWith("Sign in to"));
        }

        public HomePage LoginAs(string username, string password)
        {
            Driver.FindElement(_usernameLocator).SendKeys(username);
            Driver.FindElement(_passwordLocator).SendKeys(password);
            Driver.FindElement(_submitLocator).Click();

            return new HomePage(Driver, _returnUrl);
        }
    }
}

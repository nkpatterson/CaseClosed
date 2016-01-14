using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Shouldly;

namespace CaseClosed.UITests.Pages
{
    public class HomePage
    {
        public IWebDriver Driver { get; private set; }
        private By _loginSelector = By.CssSelector("a[href='/Account/Login']");
        private By _settingsSelector = By.CssSelector("a > i.fa-gear");
        private By _smokeTestsSelector = By.CssSelector("a[href='/SmokeTests']");

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }

        public HomePage Load(string url)
        {
            Driver.Navigate().GoToUrl(url);
            Driver.Title.ShouldStartWith("CaseClosed");

            return this;
        }

        public LoginPage ClickLogin()
        {
            Driver.FindElement(_loginSelector).Click();

            return new LoginPage(Driver);
        }

        public HomePage ClickSettings()
        {
            Driver.FindElement(_settingsSelector).Click();
            return this;
        }

        public SmokeTestsPage ClickSmokeTests()
        {
            Driver.FindElement(_smokeTestsSelector).Click();

            return new SmokeTestsPage(Driver);
        }
    }
}

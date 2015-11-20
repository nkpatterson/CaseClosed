using OpenQA.Selenium;

namespace CaseClosed.UITests.Pages
{
    public class HomePage
    {
        public IWebDriver Driver { get; private set; }
        private string _url;
        private By _settingsLocator = By.CssSelector("a.dropdown-toggle[title='Settings']");
        private By _smokeTestsLocator = By.LinkText("Smoke Tests");

        public HomePage(IWebDriver driver, string url)
        {
            Driver = driver;
            _url = url;
        }

        public HomePage ClickSettings()
        {
            Driver.FindElement(_settingsLocator).Click();
            return this;
        }

        public SmokeTestsIndexPage ClickSmokeTests()
        {
            var smokeTestsLink = Driver.FindElement(_smokeTestsLocator);
            Driver.Navigate().GoToUrl(smokeTestsLink.GetAttribute("href"));
            return new SmokeTestsIndexPage(Driver);
        }
    }
}

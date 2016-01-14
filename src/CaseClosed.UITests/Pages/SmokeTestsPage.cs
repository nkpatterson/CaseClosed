using System;
using OpenQA.Selenium;
using Shouldly;

namespace CaseClosed.UITests.Pages
{
    public class SmokeTestsPage
    {
        public IWebDriver Driver { get; private set; }
        private By _createSelector = By.Id("createSmokeTestButton");
        private By _flashSelector = By.Id("flashBody");
        private By _headerSelector = By.CssSelector("h2");

        public SmokeTestsPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public SmokeTestsPage ClickCreateSmokeTest()
        {
            Driver.FindElement(_createSelector).Click();
            return this;
        }

        public SmokeTestsPage VerifySmokeTestCreated()
        {
            var flash = Driver.FindElement(_flashSelector);
            flash.Text.ShouldBe("Smoke test created successfully!");

            return this;
        }

        public SmokeTestsPage VerifySmokeTestsReached()
        {
            var header = Driver.FindElement(_headerSelector);
            header.Text.ShouldBe("Smoke Tests");

            return this;
        }
    }
}
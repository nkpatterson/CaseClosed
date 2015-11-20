using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaseClosed.UITests.Pages
{
    public class SmokeTestsIndexPage
    {
        public IWebDriver Driver { get; private set; }
        private By _createTestLocator = By.Id("btnCreateTest");
        private By _flashLocator = By.Id("flash");

        public SmokeTestsIndexPage(IWebDriver driver)
        {
            Driver = driver;
        }

        public SmokeTestsIndexPage ClickCreateTestButton()
        {
            Driver.FindElement(_createTestLocator).Click();
            return new SmokeTestsIndexPage(Driver);
        }

        public SmokeTestsIndexPage VerifySmokeTestsReached()
        {
            Assert.IsTrue(Driver.Title.StartsWith("Smoke Tests"));

            return this;
        }

        public SmokeTestsIndexPage VerifySmokeTestWasSuccessful()
        {
            var flash = Driver.FindElement(_flashLocator);

            Assert.AreEqual("Smoke Test was successful!", flash.Text);

            return new SmokeTestsIndexPage(Driver);
        }
    }
}

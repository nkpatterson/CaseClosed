﻿using CaseClosed.UITests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;

namespace CaseClosed.UITests
{
    [TestClass]
    [DeploymentItem("IEDriverServer.exe"), DeploymentItem("chromedriver.exe")]
    public class UISmokeTests
    {
        private static IWebDriver Driver;
        private static string _homepageUrl;
        private static string _username;
        private static string _password;
        private static string _browser;

        [ClassInitialize]
        public static void Startup(TestContext context)
        {
            _homepageUrl = context.Properties["homepageUrl"]?.ToString() ?? "http://caseclosedabpdev.azurewebsites.net/";
            _username = context.Properties["username"]?.ToString() ?? "admin";
            _password = context.Properties["password"]?.ToString() ?? "123qwe";
            _browser = context.Properties["browser"]?.ToString() ?? "Chrome";
        }

        [TestInitialize]
        public void Initialize()
        {
            if (_browser == "Chrome")
            {
                Driver = new ChromeDriver();
            }
            else
            {
                Driver = new InternetExplorerDriver(new InternetExplorerOptions
                {
                    EnsureCleanSession = true
                });
            }
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Quit();
        }

        [TestMethod, TestCategory("Smoke Tests")]
        public void CanViewSmokeTests()
        {
            new HomePage(Driver)
                .Load(_homepageUrl)
                .ClickLogin()
                .LoginAs(_username, _password)
                .ClickSettings()
                .ClickSmokeTests()
                .VerifySmokeTestsReached();
        }

        [TestMethod, TestCategory("Smoke Tests")]
        public void CanCreateSmokeTest()
        {
            new HomePage(Driver)
                .Load(_homepageUrl)
                .ClickLogin()
                .LoginAs(_username, _password)
                .ClickSettings()
                .ClickSmokeTests()
                .ClickCreateSmokeTest()
                .VerifySmokeTestCreated();
        }
    }
}

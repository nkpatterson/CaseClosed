﻿using CaseClosed.UITests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using System;

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
        private static string _gridUrl;

        [ClassInitialize]
        public static void Startup(TestContext context)
        {
            _homepageUrl = context.Properties["homepageUrl"]?.ToString() ?? "https://localhost:44300/";
            _username = context.Properties["username"]?.ToString() ?? "admin";
            _password = context.Properties["password"]?.ToString() ?? "123qwe";
            _browser = context.Properties["browser"]?.ToString() ?? "Chrome";
            _gridUrl = context.Properties["gridUrl"]?.ToString() ?? "http://seleniumhub162998.westus.cloudapp.azure.com:4444/wd/hub";
        }

        [TestInitialize]
        public void Initialize()
        {
            var timeout = TimeSpan.FromMinutes(5);

            if (_browser == "Remote")
            {
                var options = new ChromeOptions();
                Driver = new RemoteWebDriver(new Uri(_gridUrl), options.ToCapabilities(), 
                    timeout);
            }
            else if (_browser == "Chrome")
            {
                Driver = new ChromeDriver(ChromeDriverService.CreateDefaultService(), 
                    new ChromeOptions(), 
                    timeout);
            }
            else
            {
                Driver = new InternetExplorerDriver(InternetExplorerDriverService.CreateDefaultService(),
                    new InternetExplorerOptions { EnsureCleanSession = true },
                    timeout);
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

using CaseClosed.UITests.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;

namespace CaseClosed.UITests
{
    [TestClass]
    public class SmokeTestSelenium
    {
        [TestMethod, TestCategory("Smoke Tests")]
        public void CanViewSmokeTests()
        {
            // Arrange
            using (var driver = new ChromeDriver())
            {
                var homepageUrl = "http://casecloseddev.azurewebsites.net/";
                var username = "nkpatterson@caseclosed.onmicrosoft.com";
                var password = "Cr0-Magn0n";

                // Act/Assert
                new LoginPage(driver, homepageUrl)
                    .LoginAs(username, password)
                    .ClickSettings()
                    .ClickSmokeTests()
                    .VerifySmokeTestsReached();

                driver.Quit();
            }
        }

        [TestMethod, TestCategory("Smoke Tests")]
        public void CanCreateSmokeTest()
        {
            using (var driver = new ChromeDriver())
            {
                var homepageUrl = "http://casecloseddev.azurewebsites.net/";
                var username = "nkpatterson@caseclosed.onmicrosoft.com";
                var password = "Cr0-Magn0n";

                new LoginPage(driver, homepageUrl)
                    .LoginAs(username, password)
                    .ClickSettings()
                    .ClickSmokeTests()
                    .VerifySmokeTestsReached()
                    .ClickCreateTestButton()
                    .VerifySmokeTestWasSuccessful();
            }
        }
    }
}

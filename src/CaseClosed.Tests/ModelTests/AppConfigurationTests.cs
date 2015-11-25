using Microsoft.VisualStudio.TestTools.UnitTesting;
using CaseClosed.Model;

namespace CaseClosed.Tests.ModelTests
{
    [TestClass]
    public class AppConfigurationTests
    {
        [TestMethod]
        public void IsBetaAvailableReturnsTrueIfUrlsAreDifferent()
        {
            // Arrange
            var config = new AppConfiguration { BetaVersion = "2.0", BetaUrl = "caseclosed-beta.azurewebsites.net" };

            // Act
            var result = config.IsBetaAvailable("caseclosed.azurewebsites.net");

            // Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsBetaAvailableReturnsFalseIfNoBetaSpecified()
        {
            // Arrange
            var config = new AppConfiguration { CurrentVersion = "1.0" };

            // Act
            var result = config.IsBetaAvailable("caseclosed.azurewebsites.net");

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void IsBetaAvailableReturnsFalseIfUrlsAreSame()
        {
            // Arrange
            var config = new AppConfiguration { BetaVersion = "2.0", BetaUrl = "caseclosed-beta.azurewebsites.net" };

            // Act
            var result = config.IsBetaAvailable("caseclosed-beta.azurewebsites.net");

            // Assert
            Assert.IsFalse(result);
        }
    }
}

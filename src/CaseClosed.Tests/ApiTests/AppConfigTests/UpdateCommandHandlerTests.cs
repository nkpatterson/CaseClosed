using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using CaseClosed.Api.Features.AppConfig;
using System.Linq;

namespace CaseClosed.Tests.ApiTests.AppConfigTests
{
    [TestClass]
    public class UpdateCommandHandlerTests
    {
        [TestMethod]
        public async Task CommandHandlerReplacesExistingAppConfiguration()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var appConfig = new AppConfiguration { CurrentVersion = "1.0" };
            var newAppConfig = new AppConfiguration { CurrentVersion = "1.0", BetaVersion = "2.0", BetaUrl = "caseclosed-beta.azurewebsites.net" };
            var fakeResult = new List<AppConfiguration> { appConfig };
            var handler = new Update.CommandHandler(client.Object, cache.Object);

            client.Setup(c => c.CreateDocumentQueryAsync<AppConfiguration>(It.IsAny<string>())).ReturnsAsync(fakeResult.AsQueryable());

            // Act
            await handler.Handle(new Update.Command { CurrentVersion = newAppConfig.CurrentVersion, BetaVersion = newAppConfig.BetaVersion, BetaUrl = newAppConfig.BetaUrl });

            // Assert
            client.Verify(c => c.UpdateDocumentAsync(It.Is<AppConfiguration>(ac => ac.BetaUrl == newAppConfig.BetaUrl && ac.BetaVersion == newAppConfig.BetaVersion)));
        }

        [TestMethod]
        public async Task CommandHandlerCreatesAppConfigurationIfItDoesNotExist()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var newAppConfig = new AppConfiguration { CurrentVersion = "1.0" };
            var handler = new Update.CommandHandler(client.Object, cache.Object);

            // Act
            await handler.Handle(new Update.Command { CurrentVersion = newAppConfig.CurrentVersion, BetaVersion = newAppConfig.BetaVersion, BetaUrl = newAppConfig.BetaUrl });

            // Assert
            client.Verify(c => c.UpdateDocumentAsync(It.Is<AppConfiguration>(ac => ac.CurrentVersion == ac.CurrentVersion)));
        }

        [TestMethod]
        public async Task CommandHandlerClearsCacheAfterUpdate()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var newAppConfig = new AppConfiguration { CurrentVersion = "1.0" };
            var handler = new Update.CommandHandler(client.Object, cache.Object);

            // Act
            await handler.Handle(new Update.Command { CurrentVersion = newAppConfig.CurrentVersion, BetaVersion = newAppConfig.BetaVersion, BetaUrl = newAppConfig.BetaUrl });

            // Assert
            cache.Verify(c => c.Clear(Index.QueryHandler.CacheKey));
        }
    }
}

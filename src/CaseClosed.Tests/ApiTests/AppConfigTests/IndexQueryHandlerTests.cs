using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Api.Features.AppConfig;
using CaseClosed.Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace CaseClosed.Tests.ApiTests.AppConfigTests
{
    [TestClass]
    public class IndexQueryHandlerTests
    {
        [TestMethod]
        public async Task QueryHandlerReturnsResultsFromDocumentClient()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var query = new Index.Query();
            var handler = new Index.QueryHandler(client.Object, cache.Object);
            var appConfig = new List<AppConfiguration> { new AppConfiguration { CurrentVersion = "1.0" } };

            client.Setup(c => c.CreateDocumentQueryAsync<AppConfiguration>(It.IsAny<string>())).ReturnsAsync(appConfig.AsQueryable());

            // Act
            AppConfiguration result = await handler.Handle(query);

            // Assert
            Assert.AreEqual(appConfig.First(), result);
        }

        [TestMethod]
        public void QueryHandlerCachesResults()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var handler = new Index.QueryHandler(client.Object, cache.Object);
            var query = new Index.Query();

            // Act
            var result = handler.Handle(query);

            // Assert
            cache.Verify(x => x.Set(typeof(Index.QueryHandler).FullName, It.IsAny<AppConfiguration>(), It.IsAny<TimeSpan?>()));
        }

        [TestMethod]
        public async Task QueryHandlerReturnsCachedResults()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var handler = new Index.QueryHandler(client.Object, cache.Object);
            var fakeResults = new AppConfiguration();

            cache.Setup(x => x.Get<AppConfiguration>(Index.QueryHandler.CacheKey)).Returns(fakeResults);

            // Act
            var result = await handler.Handle(new Index.Query());

            // Assert
            Assert.AreEqual(fakeResults, result);
        }

    }
}

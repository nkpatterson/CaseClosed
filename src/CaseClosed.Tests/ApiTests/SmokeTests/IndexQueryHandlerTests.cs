using CaseClosed.Api.Features.SmokeTests;
using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Model.SmokeTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseClosed.Tests.ApiTests.SmokeTestss
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
            var handler = new Index.QueryHandler(client.Object, cache.Object);
            var query = new Index.Query();
            var testResults = new List<SmokeTest> { new SmokeTest() };

            client.Setup(x => x.CreateDocumentQueryAsync<SmokeTest>(It.IsAny<string>())).ReturnsAsync(testResults.AsQueryable());

            // Act
            var result = await handler.Handle(query);

            // Assert
            Assert.AreEqual(testResults.Count, result.Count);
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
            cache.Verify(x => x.Set(typeof(Index.QueryHandler).FullName, It.IsAny<List<SmokeTest>>(), It.IsAny<TimeSpan?>()));
        }

        [TestMethod]
        public async Task QueryHandlerReturnsCachedResults()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var handler = new Index.QueryHandler(client.Object, cache.Object);
            var testResults = new List<SmokeTest> { new SmokeTest() };

            cache.Setup(x => x.Get<List<SmokeTest>>(Index.QueryHandler.CacheKey)).Returns(testResults);

            // Act
            var result = await handler.Handle(new Index.Query());

            // Assert
            Assert.AreEqual(testResults.Count, result.Count);
        }

        [TestMethod]
        public async Task QueryHandlerSetsSort()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var handler = new Index.QueryHandler(client.Object, cache.Object);
            var query = new Index.Query { SortBy = "Whatever", SortDirection = "DESC" };
            var testResults = new List<SmokeTest> { new SmokeTest() };

            // Act
            var result = await handler.Handle(query);

            // Assert
            client.Verify(x => x.CreateDocumentQueryAsync<SmokeTest>(It.Is<string>(sql => sql.Contains($"{query.SortBy} {query.SortDirection}"))));
        }
    }
}

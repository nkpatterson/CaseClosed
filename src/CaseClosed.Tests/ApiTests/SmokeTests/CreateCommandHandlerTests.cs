using CaseClosed.Api.Features.SmokeTests;
using CaseClosed.Api.Infrastructure.DAL;
using CaseClosed.Core.Caching;
using CaseClosed.Model.SmokeTests;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.Extensibility;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace CaseClosed.Tests.ApiTests.SmokeTests
{
    [TestClass]
    public class CreateCommandHandlerTests
    {
        [TestMethod]
        public async Task CommandHandlerCreatesNewDocument()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var telemetry = new TelemetryClient(new TelemetryConfiguration() { DisableTelemetry = true });
            var cmd = new Create.Command { CreatedBy = "nkpatterson" };
            var handler = new Create.CommandHandler(client.Object, cache.Object, telemetry);

            // Act
            var result = await handler.Handle(cmd);

            // Assert
            client.Verify(x => x.CreateDocumentAsync(It.Is<SmokeTest>(t => t.CreatedBy == cmd.CreatedBy)));
        }

        [TestMethod]
        public async Task CommandHandlerClearsCacheAfterCreation()
        {
            // Arrange
            var client = new Mock<IDocumentClient>();
            var cache = new Mock<ICache>();
            var telemetry = new TelemetryClient(new TelemetryConfiguration() { DisableTelemetry = true });
            var cmd = new Create.Command { CreatedBy = "nkpatterson" };
            var handler = new Create.CommandHandler(client.Object, cache.Object, telemetry);

            // Act
            var result = await handler.Handle(cmd);

            // Assert
            cache.Verify(x => x.Clear(Index.QueryHandler.CacheKey));
        }
    }
}

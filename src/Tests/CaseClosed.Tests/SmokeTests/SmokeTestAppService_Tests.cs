using CaseClosed.SmokeTests;
using CaseClosed.SmokeTests.Dto;
using System.Threading.Tasks;
using Xunit;
using Shouldly;
using Abp.Runtime.Caching;
using NSubstitute;
using Castle.MicroKernel.Registration;
using Abp.Application.Services.Dto;

namespace CaseClosed.Tests.SmokeTests
{
    public class SmokeTestAppService_Tests : CaseClosedTestBase
    {
        private ISmokeTestAppService _appService;
        private ICacheManager _cacheManager;
        private ICache _cache;

        public SmokeTestAppService_Tests()
        {
            _appService = Resolve<ISmokeTestAppService>();
        }

        protected override void PreInitialize()
        {
            base.PreInitialize();
            _cacheManager = Substitute.For<ICacheManager>();
            _cache = Substitute.For<ICache>();

            _cacheManager.GetCache(SmokeTestAppServiceConsts.CacheName).Returns(_cache);
            
            LocalIocManager.IocContainer.Register(
                Component.For<ICacheManager>().UsingFactoryMethod(() => _cacheManager).LifestyleSingleton());
        }

        [Fact]
        public async Task Should_create_new_SmokeTest()
        {
            // Arrange
            var input = new CreateSmokeTestInput();

            // Act
            var output = await _appService.Create(input);

            // Assert
            output.Id.ShouldNotBeNull();
            output.WasSuccessful.ShouldBeTrue();
        }

        [Fact]
        public async Task Should_invalidate_cache_after_create()
        {
            // Act
            await _appService.Create(new CreateSmokeTestInput());

            // Assert
            await _cache.Received().RemoveAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey);
        }

        [Fact]
        public async Task Should_return_recent_SmokeTests()
        {
            // Arrange
            await _appService.Create(new CreateSmokeTestInput());

            // Act
            var output = await _appService.GetAll();

            // Assert
            output.Items.Count.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async Task Should_cache_results()
        {
            // Arrange
            _cache.GetOrDefaultAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey)
                .Returns((ListResultOutput<SmokeTestListDto>)null);

            // Act
            var output = await _appService.GetAll();

            // Assert
            await _cache.Received().SetAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey, output);
        }

        [Fact]
        public async Task Should_return_cached_results()
        {
            // Arrange
            var cachedData = new[] { new SmokeTestListDto(), new SmokeTestListDto() };
            _cache.GetOrDefaultAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey)
                .Returns(new ListResultOutput<SmokeTestListDto>(cachedData));

            // Act
            var output = await _appService.GetAll();

            // Assert
            await _cache.DidNotReceiveWithAnyArgs().SetAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey, null);
        }
    }
}

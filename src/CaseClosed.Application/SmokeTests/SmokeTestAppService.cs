using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using CaseClosed.SmokeTests.Dto;
using Abp.Domain.Repositories;
using Abp.AutoMapper;
using Abp.Runtime.Caching;
using Abp.Authorization.Users;
using Abp.Authorization;
using CaseClosed.Authorization;

namespace CaseClosed.SmokeTests
{
    public class SmokeTestAppService : CaseClosedAppServiceBase, ISmokeTestAppService
    {
        private IRepository<SmokeTest> _smokeTestRepo;
        private ICacheManager _cacheManager;

        public SmokeTestAppService(IRepository<SmokeTest> smokeTestRepo, ICacheManager cacheManager)
        {
            _smokeTestRepo = smokeTestRepo;
            _cacheManager = cacheManager;
        }

        [AbpAuthorize(PermissionNames.SmokeTests_Create)]
        public async Task<CreateSmokeTestOutput> Create(CreateSmokeTestInput input)
        {
            var smokeTest = new SmokeTest
            {
                IsSuccess = true,
                Message = "Smoke test created successfully!"
            };

            var id = await _smokeTestRepo.InsertAndGetIdAsync(smokeTest);

            await _cacheManager
                .GetCache(SmokeTestAppServiceConsts.CacheName)
                .RemoveAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey);

            return new CreateSmokeTestOutput
            {
                Id = id,
                WasSuccessful = smokeTest.IsSuccess,
                Message = smokeTest.Message
            };
        }

        public async Task<ListResultOutput<SmokeTestListDto>> GetAll()
        {
            var cache = _cacheManager
                .GetCache(SmokeTestAppServiceConsts.CacheName)
                .AsTyped<string, ListResultOutput<SmokeTestListDto>>();

            var cachedResults = await cache.GetOrDefaultAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey);

            if (cachedResults != null)
                return cachedResults;

            var query = from st in _smokeTestRepo.GetAll()
                          join u in UserManager.Users on st.CreatorUserId equals u.Id
                          orderby st.CreationTime descending
                          select new SmokeTestListDto
                          {
                              Id = st.Id,
                              Creator = u.UserName,
                              CreationTime = st.CreationTime,
                              IsSuccess = st.IsSuccess,
                              Message = st.Message
                          };

            var results = query.Take(10).ToList();
            var output = new ListResultOutput<SmokeTestListDto>(results);

            await cache.SetAsync(SmokeTestAppServiceConsts.GetSmokeTestsCacheKey, output);

            return output;
        }
    }
}

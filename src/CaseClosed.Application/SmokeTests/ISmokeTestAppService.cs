using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CaseClosed.SmokeTests.Dto;
using System.Threading.Tasks;

namespace CaseClosed.SmokeTests
{
    public interface ISmokeTestAppService : IApplicationService
    {
        Task<CreateSmokeTestOutput> Create(CreateSmokeTestInput input);
        Task<ListResultOutput<SmokeTestListDto>> GetAll();
    }
}

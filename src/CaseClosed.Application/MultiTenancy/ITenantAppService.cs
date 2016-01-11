using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CaseClosed.MultiTenancy.Dto;

namespace CaseClosed.MultiTenancy
{
    public interface ITenantAppService : IApplicationService
    {
        ListResultOutput<TenantListDto> GetTenants();

        Task CreateTenant(CreateTenantInput input);
    }
}

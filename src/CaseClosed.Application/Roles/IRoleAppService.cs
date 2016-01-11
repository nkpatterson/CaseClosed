using System.Threading.Tasks;
using Abp.Application.Services;
using CaseClosed.Roles.Dto;

namespace CaseClosed.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}

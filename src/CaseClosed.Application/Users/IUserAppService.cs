using System.Threading.Tasks;
using Abp.Application.Services;
using CaseClosed.Users.Dto;

namespace CaseClosed.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}
using Abp.Authorization;
using CaseClosed.Authorization.Roles;
using CaseClosed.MultiTenancy;
using CaseClosed.Users;

namespace CaseClosed.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

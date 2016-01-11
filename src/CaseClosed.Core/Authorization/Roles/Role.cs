using Abp.Authorization.Roles;
using CaseClosed.MultiTenancy;
using CaseClosed.Users;

namespace CaseClosed.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}
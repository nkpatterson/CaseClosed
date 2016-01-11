using Abp.Application.Features;
using CaseClosed.Authorization.Roles;
using CaseClosed.MultiTenancy;
using CaseClosed.Users;

namespace CaseClosed.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}
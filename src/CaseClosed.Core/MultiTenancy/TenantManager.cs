using Abp.Domain.Repositories;
using Abp.MultiTenancy;
using CaseClosed.Authorization.Roles;
using CaseClosed.Editions;
using CaseClosed.Users;

namespace CaseClosed.MultiTenancy
{
    public class TenantManager : AbpTenantManager<Tenant, Role, User>
    {
        public TenantManager(
            IRepository<Tenant> tenantRepository, 
            IRepository<TenantFeatureSetting, long> tenantFeatureRepository, 
            EditionManager editionManager) 
            : base(
                tenantRepository, 
                tenantFeatureRepository, 
                editionManager
            )
        {
        }
    }
}
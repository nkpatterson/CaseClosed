using Abp.MultiTenancy;
using CaseClosed.Users;

namespace CaseClosed.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {
        public Tenant()
        {
            
        }

        public Tenant(string tenancyName, string name)
            : base(tenancyName, name)
        {
        }
    }
}
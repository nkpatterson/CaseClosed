using System.Data.Common;
using Abp.Zero.EntityFramework;
using CaseClosed.Authorization.Roles;
using CaseClosed.MultiTenancy;
using CaseClosed.Users;
using CaseClosed.SmokeTests;
using System.Data.Entity;

namespace CaseClosed.EntityFramework
{
    public class CaseClosedDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...
        public DbSet<SmokeTest> SmokeTests { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public CaseClosedDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CaseClosedDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CaseClosedDbContext since ABP automatically handles it.
         */
        public CaseClosedDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CaseClosedDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}

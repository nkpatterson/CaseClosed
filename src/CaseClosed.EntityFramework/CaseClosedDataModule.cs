using System.Data.Entity;
using System.Reflection;
using Abp.Modules;
using Abp.Zero.EntityFramework;
using CaseClosed.EntityFramework;

namespace CaseClosed
{
    [DependsOn(typeof(AbpZeroEntityFrameworkModule), typeof(CaseClosedCoreModule))]
    public class CaseClosedDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

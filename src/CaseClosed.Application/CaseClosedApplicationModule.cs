using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;

namespace CaseClosed
{
    [DependsOn(typeof(CaseClosedCoreModule), typeof(AbpAutoMapperModule))]
    public class CaseClosedApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

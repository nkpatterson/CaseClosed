using System.Reflection;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.RedisCache;
using Abp.Runtime.Caching;

namespace CaseClosed
{
    [DependsOn(typeof(CaseClosedCoreModule), typeof(AbpAutoMapperModule))]
    public class CaseClosedApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.Register<ICacheManager, AbpRedisCacheManager>();
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}

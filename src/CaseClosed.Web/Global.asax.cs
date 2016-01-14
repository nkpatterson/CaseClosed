using System;
using System.Linq;
using Abp.Dependency;
using Abp.Web;
using CaseClosed.EntityFramework;
using CaseClosed.Migrations.SeedData;
using Castle.Facilities.Logging;

namespace CaseClosed.Web
{
    public class MvcApplication : AbpWebApplication
    {
        protected override void Application_Start(object sender, EventArgs e)
        {
            IocManager.Instance.IocContainer.AddFacility<LoggingFacility>(f => f.UseLog4Net().WithConfig("log4net.config"));
            base.Application_Start(sender, e);
            InitializeData();
        }

        private void InitializeData()
        {
            var context = IocManager.Instance.IocContainer.Resolve<CaseClosedDbContext>();
            if (!context.Users.Any())
            {
                new InitialDataBuilder(context).Build();
            }
        }
    }
}

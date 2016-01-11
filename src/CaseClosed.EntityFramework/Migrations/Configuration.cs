using System.Data.Entity.Migrations;
using CaseClosed.Migrations.SeedData;

namespace CaseClosed.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CaseClosed.EntityFramework.CaseClosedDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "CaseClosed";
        }

        protected override void Seed(CaseClosed.EntityFramework.CaseClosedDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}

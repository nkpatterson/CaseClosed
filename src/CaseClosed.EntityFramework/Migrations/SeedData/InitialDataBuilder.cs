using CaseClosed.EntityFramework;
using EntityFramework.DynamicFilters;

namespace CaseClosed.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly CaseClosedDbContext _context;

        public InitialDataBuilder(CaseClosedDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}

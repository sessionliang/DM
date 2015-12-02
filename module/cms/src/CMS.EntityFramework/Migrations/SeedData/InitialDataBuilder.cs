using CMS.EntityFramework;

namespace CMS.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly CMSDbContext _context;

        public InitialDataBuilder(CMSDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}

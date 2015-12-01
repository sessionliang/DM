using System.Data.Entity.Migrations;
using CMS.Migrations.SeedData;
using EntityFramework.DynamicFilters;

namespace CMS.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<CMS.EntityFramework.CMSDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "CMS";
        }

        protected override void Seed(CMS.EntityFramework.CMSDbContext context)
        {
            context.DisableAllFilters();
            new InitialDataBuilder(context).Build();
        }
    }
}

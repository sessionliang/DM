using System.Data.Common;
using System.Data.Entity;
using Abp.Zero.EntityFramework;
using CMS.Authorization.Roles;
using CMS.CMSEntities;
using CMS.MultiTenancy;
using CMS.Users;

namespace CMS.EntityFramework
{
    public class CMSDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        public virtual IDbSet<NodeInfo> CmsNode { set; get; }

        public virtual IDbSet<ContentInfo> CmsModelContent { set; get; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public CMSDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in CMSDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of CMSDbContext since ABP automatically handles it.
         */
        public CMSDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public CMSDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}

using Abp.Application.Features;
using CMS.Authorization.Roles;
using CMS.MultiTenancy;
using CMS.Users;

namespace CMS.Features
{
    public class FeatureValueStore : AbpFeatureValueStore<Tenant, Role, User>
    {
        public FeatureValueStore(TenantManager tenantManager)
            : base(tenantManager)
        {
        }
    }
}
using Abp.Authorization.Roles;
using CMS.MultiTenancy;
using CMS.Users;

namespace CMS.Authorization.Roles
{
    public class Role : AbpRole<Tenant, User>
    {

    }
}
using Abp.MultiTenancy;
using CMS.Users;

namespace CMS.MultiTenancy
{
    public class Tenant : AbpTenant<Tenant, User>
    {

    }
}
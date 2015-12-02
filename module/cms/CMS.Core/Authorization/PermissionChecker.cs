using Abp.Authorization;
using CMS.Authorization.Roles;
using CMS.MultiTenancy;
using CMS.Users;

namespace CMS.Authorization
{
    public class PermissionChecker : PermissionChecker<Tenant, Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {

        }
    }
}

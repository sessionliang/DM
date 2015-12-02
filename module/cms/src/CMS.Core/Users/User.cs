using System;
using Abp.Authorization.Users;
using Abp.Extensions;
using CMS.MultiTenancy;

namespace CMS.Users
{
    public class User : AbpUser<Tenant, User>
    {
        public static string CreateRandomPassword()
        {
            return Guid.NewGuid().ToString("N").Truncate(16);
        }
    }
}
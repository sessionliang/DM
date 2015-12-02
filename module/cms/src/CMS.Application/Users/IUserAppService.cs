using System.Threading.Tasks;
using Abp.Application.Services;
using CMS.Users.Dto;

namespace CMS.Users
{
    public interface IUserAppService : IApplicationService
    {
        Task ProhibitPermission(ProhibitPermissionInput input);

        Task RemoveFromRole(long userId, string roleName);
    }
}
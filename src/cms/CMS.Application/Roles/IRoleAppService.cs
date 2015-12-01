using System.Threading.Tasks;
using Abp.Application.Services;
using CMS.Roles.Dto;

namespace CMS.Roles
{
    public interface IRoleAppService : IApplicationService
    {
        Task UpdateRolePermissions(UpdateRolePermissionsInput input);
    }
}

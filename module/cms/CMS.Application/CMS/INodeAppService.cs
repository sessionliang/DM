using Abp.Application.Services;
using CMS.CMS.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS
{
    /// <summary>
    /// 栏目appservice
    /// </summary>
    public interface INodeAppService : IApplicationService
    {
        GetNodesOutput GetNodes(GetNodesInput input);
    }
}

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
        Task<GetNodesOutput> GetNodes(GetNodesInput input);
        Task<GetNodesOutput> GetNodeById(GetNodesInput input);
        Task<GetNodesOutput> GetNodesByParentId(GetNodesInput input);
        Task<GetNodesOutput> GetNodeByNodeIndex(GetNodesInput input);
        Task<GetNodesOutput> GetNodesByNodeIndex(GetNodesInput input);
        Task<CreateNodeOutput> CreateNode(CreateNodeInput input);
        Task<UpdateNodeOutput> UpdateNode(UpdateNodeInput input);
    }
}

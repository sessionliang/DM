using Abp.Application.Services;
using AutoMapper;
using CMS.CMS.Dto;
using CMS.CMSEntities;
using CMS.CMSEntities.Node;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS
{
    public class NodeAppService<TNodeInfo> : CMSAppServiceBase, INodeAppService
                where TNodeInfo : NodeInfo
    {
        private NodeManager<TNodeInfo> _nodeManager;

        /// <summary>
        /// 获取栏目集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public Task GetNodes(Dto.GetNodesInput input)
        {
            Dto.GetNodesOutput output = new GetNodesOutput();
            if (input.NodeId > 0)
            {
                output.Nodes.Add(Mapper.Map<Task<TNodeInfo>>(await _nodeManager.GetNodeByNodeId(input.NodeId)));
            }
            return output;
        }
    }
}

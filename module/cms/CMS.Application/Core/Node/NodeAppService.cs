using Abp.Application.Services;
using AutoMapper;
using CMS.Core.Dto;
using CMS.CMSEntities;
using CMS.CMSEntities.Node;
using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CMS.Repository;
using Abp.IdentityFramework;

namespace CMS.Core
{
    public class NodeAppService : CMSAppServiceBase, INodeAppService
    {
        private readonly INodeRepository _nodeRepository;
        private readonly NodeManager _nodeManager;

        public NodeAppService(NodeManager nodeManager, INodeRepository nodeRepository)
        {
            _nodeManager = nodeManager;
            _nodeRepository = nodeRepository;
        }

        /// <summary>
        /// 获取栏目集合
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public GetNodesOutput GetNodes(GetNodesInput input)
        {
            GetNodesOutput output = new GetNodesOutput();
            int limit = input.Limit.HasValue ? input.Limit.Value : CMSConsts.PageLimit;
            int offset = input.Offset.HasValue ? input.Offset.Value : 0;
            var nodes = Mapper.DynamicMap<IList<NodeDto>>(_nodeRepository.GetNodesPagingByPublishmentSystemId(input.PublishmentSystemId, limit, offset));
            output.Nodes = nodes;
            return output;
        }

        /// <summary>
        /// 根据id获取栏目
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<GetNodesOutput> GetNodeById(GetNodesInput input)
        {
            GetNodesOutput output = new GetNodesOutput();
            //根据ID查询
            if (input.NodeId.HasValue)
            {
                var node = Mapper.DynamicMap<NodeDto>(await _nodeRepository.FirstOrDefaultAsync(input.NodeId.Value));
                output.Nodes.Add(node);
                output.Node = node;
            }
            return output;
        }

        /// <summary>
        /// 根据parentId获取栏目集合
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<GetNodesOutput> GetNodesByParentId(GetNodesInput input)
        {
            GetNodesOutput output = new GetNodesOutput();
            //根据parentId查询
            if (input.ParentId.HasValue)
            {
                var nodes = Mapper.DynamicMap<IList<NodeDto>>(await _nodeRepository.FindByParentIdAsync(input.ParentId.Value));
                output.Nodes = nodes;
            }
            return output;
        }

        /// <summary>
        /// 根据publishmentSystemId, nodeIndex获取栏目集合
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<GetNodesOutput> GetNodeByNodeIndex(GetNodesInput input)
        {
            GetNodesOutput output = new GetNodesOutput();
            //根据publishmentSystemId, nodeIndex查询
            if (!string.IsNullOrEmpty(input.NodeIndex))
            {
                var node = Mapper.DynamicMap<NodeDto>(await _nodeRepository.FindByIndexAsync(input.PublishmentSystemId,
                    input.NodeIndex));
                output.Nodes.Add(node);
                output.Node = node;
            }
            return output;
        }

        /// <summary>
        /// 根据publishmentSystemId, nodeName获取栏目集合
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<GetNodesOutput> GetNodesByNodeIndex(GetNodesInput input)
        {
            GetNodesOutput output = new GetNodesOutput();
            //根据publishmentSystemId, nodeName查询
            if (!string.IsNullOrEmpty(input.NodeName))
            {
                var nodes = Mapper.DynamicMap<IList<NodeDto>>(await _nodeRepository.FindByNameAsync(input.PublishmentSystemId,
                    input.NodeName));
                output.Nodes = nodes;
            }
            return output;
        }


        /// <summary>
        /// 创建Node
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<CreateNodeOutput> CreateNode(CreateNodeInput input)
        {
            var nodeInfo = new NodeInfo()
            {
                PublishmentSystemId = input.PublishmentSystemId,
                NodeName = input.NodeName
            };
            if (!string.IsNullOrEmpty(input.NodeIndex))
            {
                nodeInfo.NodeIndexName = input.NodeIndex;
            }
            if (input.ChannelTemplateId.HasValue)
            {
                nodeInfo.ChannelTemplateId = input.ChannelTemplateId.Value;
            }
            if (input.ContentTemplateId.HasValue)
            {
                nodeInfo.ContentTemplateId = input.ContentTemplateId.Value;
            }
            if (!string.IsNullOrEmpty(input.ContentModelId))
            {
                nodeInfo.ContentModelId = input.ContentModelId;
            }
            if (input.ParentId.HasValue)
            {
                nodeInfo.ParentId = input.ParentId.Value;
            }
            else
            {
                nodeInfo.ParentId = input.PublishmentSystemId;
            }

            //检测重复
            var result = await _nodeManager.CheckDuplicateNodeIndex(nodeInfo.Id, nodeInfo.PublishmentSystemId, nodeInfo.NodeIndexName);
            if (!result.Succeeded)
            {
                result.CheckErrors();
            }

            return Mapper.DynamicMap<CreateNodeOutput>(await _nodeRepository.InsertAsync(nodeInfo));
        }

        /// <summary>
        /// 修改Node
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<UpdateNodeOutput> UpdateNode(UpdateNodeInput input)
        {
            var node = await _nodeRepository.FirstOrDefaultAsync(input.NodeId);

            if (!string.IsNullOrEmpty(input.NodeName))
            {
                node.NodeName = input.NodeName;
            }
            if (!string.IsNullOrEmpty(input.NodeIndex))
            {
                node.NodeIndexName = input.NodeIndex;
            }
            if (input.ChannelTemplateId.HasValue)
            {
                node.ChannelTemplateId = input.ChannelTemplateId.Value;
            }
            if (input.ContentTemplateId.HasValue)
            {
                node.ContentTemplateId = input.ContentTemplateId.Value;
            }
            if (!string.IsNullOrEmpty(input.ContentModelId))
            {
                node.ContentModelId = input.ContentModelId;
            }

            //检测重复
            var result = await _nodeManager.CheckDuplicateNodeIndex(node.Id, node.PublishmentSystemId, node.NodeIndexName);
            if (!result.Succeeded)
            {
                result.CheckErrors();
            }
            return Mapper.DynamicMap<UpdateNodeOutput>(await _nodeRepository.UpdateAsync(node));
        }
    }
}

using Abp.Application.Services;
using AutoMapper;
using CMS.CMS.Dto;
using CMS.CMSEntities;
using CMS.CMSEntities.Node;
using CMS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS
{
    public class NodeAppService : CMSAppServiceBase, INodeAppService
    {
        private NodeManager _nodeManager;

        /// <summary>
        /// 获取栏目集合
        /// 1. 根据id
        /// 2. 根据parentId
        /// 3. 根据publishmentSystemId, nodeIndex
        /// 4. 根据publishmentSystemId, nodeName
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task<GetNodesOutput> GetNodes(GetNodesInput input)
        {
            GetNodesOutput output = new GetNodesOutput();
            //根据ID查询
            if (input.NodeId.HasValue)
            {
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIdAsync(input.NodeId.Value));
                output.Nodes.Add(node);
                output.Node = node;
            }
            //根据parentId查询
            else if (input.ParentId.HasValue)
            {
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodeByParentIdAsync(input.ParentId.Value));
                output.Nodes = nodes;
            }
            //根据nodeIndex查询
            else if (!string.IsNullOrEmpty(input.NodeIndex))
            {
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIndexAsync(input.PublishmentSystemId,
                    input.NodeIndex));
                output.Nodes.Add(node);
                output.Node = node;
            }
            //根据nodeName查询
            else if (!string.IsNullOrEmpty(input.NodeName))
            {
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodesByNodeNameAsync(input.PublishmentSystemId, input.NodeName));
                output.Nodes = nodes;
            }
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
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIdAsync(input.NodeId.Value));
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
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodeByParentIdAsync(input.ParentId.Value));
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
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIndexAsync(input.PublishmentSystemId,
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
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodesByNodeNameAsync(input.PublishmentSystemId,
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
            return Mapper.Map<CreateNodeOutput>(await _nodeManager.InsertAsync(nodeInfo));
        }

        /// <summary>
        /// 修改Node
        /// </summary>
        /// <param name="?"></param>
        /// <returns></returns>
        public async Task<UpdateNodeOutput> UpdateNode(UpdateNodeInput input)
        {
            var node = await _nodeManager.GetNodeByNodeIdAsync(input.NodeId);

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

            return Mapper.Map<UpdateNodeOutput>(await _nodeManager.UpdateAsync(node));
        }
    }
}

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
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIdAsync(TranslateUtils.GetInt64ValueFromNullable(input.NodeId)));
                output.Nodes.Add(node);
                output.Node = node;
            }
            //根据parentId查询
            else if (input.ParentId.HasValue)
            {
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodeByParentIdAsync(TranslateUtils.GetInt64ValueFromNullable(input.ParentId)));
                output.Nodes = nodes;
            }
            //根据nodeIndex查询
            else if (input.NodeIndex.HasValue)
            {
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIndexAsync(input.PublishmentSystemId,
                    TranslateUtils.GetStringValueFromNullable(input.NodeIndex)));
                output.Nodes.Add(node);
                output.Node = node;
            }
            //根据nodeName查询
            else if (input.NodeName.HasValue)
            {
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodesByNodeNameAsync(input.PublishmentSystemId, TranslateUtils.GetStringValueFromNullable(input.NodeName)));
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
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIdAsync(TranslateUtils.GetInt64ValueFromNullable(input.NodeId)));
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
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodeByParentIdAsync(TranslateUtils.GetInt64ValueFromNullable(input.ParentId)));
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
            if (input.NodeIndex.HasValue)
            {
                var node = Mapper.Map<NodeDto>(await _nodeManager.GetNodeByNodeIndexAsync(input.PublishmentSystemId,
                    TranslateUtils.GetStringValueFromNullable(input.NodeIndex)));
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
            if (input.NodeName.HasValue)
            {
                var nodes = Mapper.Map<IList<NodeDto>>(await _nodeManager.GetNodesByNodeNameAsync(input.PublishmentSystemId,
                    TranslateUtils.GetStringValueFromNullable(input.NodeName)));
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
                NodeName = input.NodeName,
                NodeIndexName = TranslateUtils.GetStringValueFromNullable(input.NodeIndex),
                ChannelTemplateId = TranslateUtils.GetInt64ValueFromNullable(input.ChannelTemplateId),
                ContentTemplateId = TranslateUtils.GetInt64ValueFromNullable(input.ContentTemplateId),
                ContentModelId = TranslateUtils.GetStringValueFromNullable(input.ContentModelId)
            };

            if (!input.ParentId.HasValue)
            {
                input.ParentId = input.PublishmentSystemId;
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

            if (input.NodeName.HasValue)
            {
                node.NodeName = input.NodeName.Value;
            }
            if (input.NodeIndex.HasValue)
            {
                node.NodeIndexName = input.NodeIndex.Value;
            }
            if (input.ChannelTemplateId.HasValue)
            {
                node.ChannelTemplateId = input.ChannelTemplateId.Value;
            }
            if (input.ContentTemplateId.HasValue)
            {
                node.ContentTemplateId = input.ContentTemplateId.Value;
            }
            if (input.ContentModelId.HasValue)
            {
                node.ContentModelId = input.ContentModelId.Value;
            }

            return Mapper.Map<UpdateNodeOutput>(await _nodeManager.UpdateAsync(node));
        }
    }
}

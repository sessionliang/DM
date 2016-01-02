using Abp.Domain.Services;
using Abp.IdentityFramework;
using Abp.Localization;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMSEntities.Node
{
    public abstract class NodeManager : IDomainService
    {
        private readonly NodeStore<NodeInfo> _abpStore;

        public ILocalizationManager LocalizationManager { get; set; }

        protected NodeManager(NodeStore<NodeInfo> store)
        {
            _abpStore = store;
            LocalizationManager = NullLocalizationManager.Instance;
        }

        /// <summary>
        /// 根据nodeId获取node
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public async Task<NodeInfo> GetNodeByNodeIdAsync(long nodeId)
        {
            var node = await _abpStore.FindByIdAsync(nodeId);
            if (node == null)
            {
                throw new Exception("There is no node for id:" + nodeId);
            }
            return node;
        }

        /// <summary>
        /// 根据parentId获取node
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public async Task<IList<NodeInfo>> GetNodeByParentIdAsync(long parentId)
        {
            var node = await _abpStore.FindByParentIdAsync(parentId);

            if (node == null)
            {
                throw new Exception("There is no nodes for parentId:" + parentId);
            }
            return node;
        }

        /// <summary>
        /// 根据nodeName获取nodes
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public async Task<IList<NodeInfo>> GetNodesByNodeNameAsync(long publishmentSystemId, string nodeName)
        {
            var node = await _abpStore.FindByNameAsync(publishmentSystemId, nodeName);

            if (node == null)
            {
                throw new Exception("There is no node for publishmentSystemId:" + publishmentSystemId + ", nodeName:" + nodeName);
            }
            return node;
        }

        /// <summary>
        /// 根据nodeName获取nodes
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public async Task<NodeInfo> GetNodeByNodeIndexAsync(long publishmentSystemId, string nodeIndex)
        {
            var node = await _abpStore.FindByIndexAsync(publishmentSystemId, nodeIndex);

            if (node == null)
            {
                throw new Exception("There is no node for publishmentSystemId:" + publishmentSystemId + ", nodeIndex:" + nodeIndex);
            }
            return node;
        }

        /// <summary>
        /// 创建栏目
        /// </summary>
        /// <param name="nodeInfo"></param>
        /// <returns></returns>
        public async Task<NodeInfo> InsertAsync(NodeInfo nodeInfo)
        {
            var result = await CheckDuplicateNodeIndex(nodeInfo.Id, nodeInfo.PublishmentSystemId, nodeInfo.NodeIndexName);
            if (!result.Succeeded)
            {
                result.CheckErrors();
            }

            return await _abpStore.CreateAsync(nodeInfo);
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="nodeInfo"></param>
        /// <returns></returns>
        public async Task<NodeInfo> UpdateAsync(NodeInfo nodeInfo)
        {
            var result = await CheckDuplicateNodeIndex(nodeInfo.Id, nodeInfo.PublishmentSystemId, nodeInfo.NodeIndexName);
            if (!result.Succeeded)
            {
                result.CheckErrors();
            }

            return await _abpStore.UpdateAsync(nodeInfo);
        }

        /// <summary>
        /// 检测nodeIndex是否存在
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="nodeIndexName"></param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> CheckDuplicateNodeIndex(long? expectedNodeId, long publishmentSystemId, string nodeIndexName)
        {
            var node = (await _abpStore.FindByIndexAsync(publishmentSystemId, nodeIndexName));
            if (node != null && node.Id != expectedNodeId)
            {
                return AbpIdentityResult.Failed(string.Format(L("Identity.DuplicateIndexName"), nodeIndexName));
            }
            return IdentityResult.Success;
        }

        /// <summary>
        /// 分页获取node集合
        /// </summary>
        /// <param name="p"></param>
        /// <param name="nullable1"></param>
        /// <param name="nullable2"></param>
        /// <returns></returns>
        public IList<NodeInfo> GetNodesPaging(long publishmentSystemId, int limit, int offset)
        {
            var nodes = _abpStore.FindByPublishmentSystemIdAsync(publishmentSystemId, limit, offset);

            if (nodes == null)
            {
                throw new Exception("There is no nodes for parentId:" + publishmentSystemId);
            }
            return nodes;
        }


        /// <summary>
        /// 获取本地化信息
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private string L(string name)
        {
            return LocalizationManager.GetString(CMSConsts.LocalizationSourceName, name);
        }

    }
}

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
    public class NodeManager
    {
        protected NodeStore<NodeInfo> AbpStore { get; private set; }

        public ILocalizationManager LocalizationManager { get; set; }

        public NodeManager(NodeStore<NodeInfo> store)
        {
            AbpStore = store;
        }

        /// <summary>
        /// 根据nodeId获取node
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public async Task<NodeInfo> GetNodeByNodeIdAsync(long nodeId)
        {
            var node = await AbpStore.FindByIdAsync(nodeId);
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
            var node = await AbpStore.FindByParentIdAsync(parentId);

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
            var node = await AbpStore.FindByNameAsync(publishmentSystemId, nodeName);

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
            var node = await AbpStore.FindByIndexAsync(publishmentSystemId, nodeIndex);

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

            return await AbpStore.CreateAsync(nodeInfo);
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

            return await AbpStore.UpdateAsync(nodeInfo);
        }

        /// <summary>
        /// 检测nodeIndex是否存在
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="nodeIndexName"></param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> CheckDuplicateNodeIndex(long? expectedNodeId, long publishmentSystemId, string nodeIndexName)
        {
            var node = (await AbpStore.FindByIndexAsync(publishmentSystemId, nodeIndexName));
            if (node != null && node.Id != expectedNodeId)
            {
                return AbpIdentityResult.Failed(string.Format(L("Identity.DuplicateIndexName"), nodeIndexName));
            }
            return IdentityResult.Success;
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

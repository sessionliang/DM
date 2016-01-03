using Abp.Domain.Repositories;
using Abp.Domain.Services;
using Abp.IdentityFramework;
using Abp.Localization;
using CMS.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMSEntities.Node
{
    public class NodeManager : IDomainService
    {
        private readonly INodeRepository _nodeRepository;

        public ILocalizationManager LocalizationManager { get; set; }

        public NodeManager(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
            LocalizationManager = NullLocalizationManager.Instance;
        }

        /// <summary>
        /// 检测nodeIndex是否存在
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="nodeIndexName"></param>
        /// <returns></returns>
        public virtual async Task<IdentityResult> CheckDuplicateNodeIndex(long? expectedNodeId, long publishmentSystemId, string nodeIndexName)
        {
            var node = (await _nodeRepository.FindByIndexAsync(publishmentSystemId, nodeIndexName));
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

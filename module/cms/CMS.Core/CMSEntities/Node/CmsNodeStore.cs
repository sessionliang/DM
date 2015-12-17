using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMSEntities.Node
{
    public class CmsNodeStore<TNodeInfo>
        where TNodeInfo : CmsNodeInfo
    {
        /// <summary>
        /// 栏目仓储
        /// </summary>
        private readonly IRepository<TNodeInfo, long> _cmsNodeRepository;

        /// <summary>
        /// 构造器
        /// </summary>
        /// <param name="cmsNodeRepository"></param>
        public CmsNodeStore(IRepository<TNodeInfo, long> cmsNodeRepository)
        {
            _cmsNodeRepository = cmsNodeRepository;
        }

        /// <summary>
        /// 添加栏目（异步）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual async Task CreateAsync(TNodeInfo node)
        {
            await _cmsNodeRepository.InsertAsync(node);
        }

        /// <summary>
        /// 添加栏目，并返回ID
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual long Create(TNodeInfo node)
        {
            return _cmsNodeRepository.InsertAndGetId(node);
        }

        /// <summary>
        /// 更新栏目（异步）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual async Task UpdateAsync(TNodeInfo node)
        {
            await _cmsNodeRepository.UpdateAsync(node);
        }

        /// <summary>
        /// 更新栏目
        /// </summary>
        /// <param name="node"></param>
        public virtual void Update(TNodeInfo node)
        {
            _cmsNodeRepository.Update(node);
        }

        /// <summary>
        /// 删除栏目（异步）
        /// </summary>
        /// <param name="node"></param>
        /// <returns></returns>
        public virtual async Task DeleteAsync(TNodeInfo node)
        {
            await _cmsNodeRepository.DeleteAsync(node);
        }

        /// <summary>
        /// 删除栏目
        /// </summary>
        /// <param name="node"></param>
        public virtual void Delete(TNodeInfo node)
        {
            _cmsNodeRepository.Delete(node);
        }

        /// <summary>
        /// 根据栏目Id获取栏目
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        public virtual Task<TNodeInfo> FindByIdAsync(long nodeId)
        {
            return _cmsNodeRepository.FirstOrDefaultAsync(nodeId);
        }

        /// <summary>
        /// 根据栏目名称，站点ID获取栏目
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public virtual async Task<TNodeInfo> FindByNameAsync(long publishmentSystemId, string nodeName)
        {
            return await _cmsNodeRepository.FirstOrDefaultAsync(
                    node => node.NodeName == nodeName && node.PublishmentSystemId == publishmentSystemId
                );
        }

        /// <summary>
        /// 根据栏目索引，站点ID获取栏目
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="nodeIndexName"></param>
        /// <returns></returns>
        public virtual async Task<TNodeInfo> FindByIndexAsync(long publishmentSystemId, string nodeIndexName)
        {
            return await _cmsNodeRepository.FirstOrDefaultAsync(
                node => node.NodeIndexName == nodeIndexName && node.PublishmentSystemId == publishmentSystemId
                );
        }

        /// <summary>
        /// 根据站点Id，父级Id获取栏目集合
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public virtual async Task<IList<TNodeInfo>> GetNodeInfosAsync(long publishmentSystemId, long parentNodeId)
        {
            if (parentNodeId > 0)
            {
                return (await _cmsNodeRepository.GetAllListAsync(node => node.PublishmentSystemId == publishmentSystemId && node.ParentId == parentNodeId)).ToList();
            }
            else
            {
                return (await _cmsNodeRepository.GetAllListAsync(node => node.PublishmentSystemId == publishmentSystemId)).ToList();
            }
        }
    }
}

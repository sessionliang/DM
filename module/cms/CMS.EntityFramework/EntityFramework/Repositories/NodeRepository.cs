using Abp.EntityFramework;
using CMS.CMSEntities;
using CMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.EntityFramework.Repositories
{
    public class NodeRepository : CMSRepositoryBase<NodeInfo, long>, INodeRepository
    {

        public NodeRepository(IDbContextProvider<CMSDbContext> context)
            : base(context)
        {

        }

        /// <summary>
        /// 根据栏目父级Id获取栏目
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        public async Task<IList<NodeInfo>> FindByParentIdAsync(long parentId)
        {
            return await base.GetAllListAsync(
                    node => node.ParentId == parentId
                );
        }

        /// <summary>
        /// 根据栏目名称，站点ID获取栏目
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        public async Task<IList<NodeInfo>> FindByNameAsync(long publishmentSystemId, string nodeName)
        {
            return await base.GetAllListAsync(
        node => node.PublishmentSystemId == publishmentSystemId && node.NodeName == nodeName
    );
        }

        /// <summary>
        /// 根据栏目索引，站点ID获取栏目
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="nodeIndexName"></param>
        /// <returns></returns>
        public async Task<NodeInfo> FindByIndexAsync(long publishmentSystemId, string nodeIndexName)
        {
            return await base.FirstOrDefaultAsync(
node => node.PublishmentSystemId == publishmentSystemId && node.NodeIndexName == nodeIndexName
);
        }

        /// <summary>
        /// 根据站点Id，父级Id获取栏目集合
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        public async Task<IList<NodeInfo>> GeNodeInfosAsync(long publishmentSystemId, long parentNodeId)
        {
            if (parentNodeId > 0)
            {
                return (await base.GetAllListAsync(node => node.PublishmentSystemId == publishmentSystemId && node.ParentId == parentNodeId)).ToList();
            }
            else
            {
                return (await base.GetAllListAsync(node => node.PublishmentSystemId == publishmentSystemId)).ToList();
            }
        }

        /// <summary>
        /// 分页获取node集合
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public IList<NodeInfo> GetNodesPagingByPublishmentSystemId(long publishmentSystemId, int limit, int offset)
        {
            var query = base.GetAll();
            return query.Where(node => node.PublishmentSystemId == publishmentSystemId)
                   .OrderBy(node => node.Id)
                   .OrderBy(node => node.Taxis)
                   .Skip(offset)
                   .Take(limit)
                   .ToList();
        }
    }
}

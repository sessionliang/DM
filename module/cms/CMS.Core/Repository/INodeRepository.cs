using Abp.Domain.Repositories;
using CMS.CMSEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository
{
    public interface INodeRepository : IRepository<NodeInfo, long>
    {
        /// <summary>
        /// 根据栏目Id获取栏目
        /// </summary>
        /// <param name="nodeId"></param>
        /// <returns></returns>
        //Task<NodeInfo> FindByIdAsync(long nodeId);

        /// <summary>
        /// 根据栏目父级Id获取栏目
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        Task<IList<NodeInfo>> FindByParentIdAsync(long parentId);


        /// <summary>
        /// 根据栏目名称，站点ID获取栏目
        /// </summary>
        /// <param name="nodeName"></param>
        /// <returns></returns>
        Task<IList<NodeInfo>> FindByNameAsync(long publishmentSystemId, string nodeName);


        /// <summary>
        /// 根据栏目索引，站点ID获取栏目
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="nodeIndexName"></param>
        /// <returns></returns>
        Task<NodeInfo> FindByIndexAsync(long publishmentSystemId, string nodeIndexName);


        /// <summary>
        /// 根据站点Id，父级Id获取栏目集合
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="parentNodeId"></param>
        /// <returns></returns>
        Task<IList<NodeInfo>> GeNodeInfosAsync(long publishmentSystemId, long parentNodeId);

        /// <summary>
        /// 分页获取node集合
        /// </summary>
        /// <param name="publishmentSystemId"></param>
        /// <param name="limit"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        IList<NodeInfo> GetNodesPagingByPublishmentSystemId(long publishmentSystemId, int limit, int offset);

    }
}

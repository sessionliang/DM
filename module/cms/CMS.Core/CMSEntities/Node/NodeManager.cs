using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMSEntities.Node
{
    public class NodeManager<TNodeInfo>
        where TNodeInfo : NodeInfo
    {
        protected NodeStore<TNodeInfo> AbpStore { get; private set; }

        public NodeManager(NodeStore<TNodeInfo> store)
        {
            AbpStore = store;
        }

        public Task<TNodeInfo> GetNodeByNodeId(long nodeId)
        {
            var node = AbpStore.FindByIdAsync(nodeId);
            if (node == null)
            {
                throw new Exception("There is no node for id:" + nodeId);
            }
            return node;
        }
    }
}

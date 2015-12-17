using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMSEntities.Node
{
    public class CmsNodeManager<TNodeInfo>
        where TNodeInfo : CmsNodeInfo
    {
        protected CmsNodeStore<TNodeInfo> AbpStore { get; private set; }

        public CmsNodeManager(CmsNodeStore<TNodeInfo> store)
        {
            AbpStore = store;
        }

    }
}

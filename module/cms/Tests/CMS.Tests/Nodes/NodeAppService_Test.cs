using CMS.Core;
using CMS.Core.Dto;
using CMS.Tests.Sessions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace CMS.Tests.Nodes
{
    public class NodeAppService_Test : CMSTestBase
    {
        private readonly INodeAppService _nodeAppService;
        public NodeAppService_Test()
        {
            _nodeAppService = Resolve<INodeAppService>();
        }

        [Fact]
        public void GetNodes_PublishmentSystemId_Should_Be_1()
        {
            var output = _nodeAppService.GetNodes(new GetNodesInput() { Limit = 25, Offset = 0, PublishmentSystemId = 1 });
            output.Items.ShouldAllBe(node => node.PublishmentSystemId == 1);
        }
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS.Dto
{
    public class GetNodesOutput : IOutputDto
    {
        public Task<IList<NodeDto>> Nodes { get; set; }
    }
}

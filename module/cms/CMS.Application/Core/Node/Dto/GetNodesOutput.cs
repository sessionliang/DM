using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Core.Dto
{
    public class GetNodesOutput : IOutputDto
    {
        /// <summary>
        /// 查询集合的时候
        /// </summary>
        public IList<NodeDto> Nodes { get; set; }

        /// <summary>
        /// 查询个体的时候
        /// </summary>
        public NodeDto Node { get; set; }
    }
}

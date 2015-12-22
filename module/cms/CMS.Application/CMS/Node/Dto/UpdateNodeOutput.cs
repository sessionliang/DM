using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS.Dto
{
    public class UpdateNodeOutput : IOutputDto
    {
        /// <summary>
        /// 查询个体的时候
        /// </summary>
        public NodeDto Node { get; set; }
    }
}

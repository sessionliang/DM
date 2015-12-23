using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS.Dto
{
    public class GetNodesInput : CMSInputDtoBase
    {
        public long? NodeId { get; set; }
        public string NodeIndex { get; set; }
        public string NodeName { get; set; }
        public long? ParentId { get; set; }
    }
}

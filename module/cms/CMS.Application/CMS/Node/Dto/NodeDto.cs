using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS.Dto
{
    public class NodeDto : EntityDto<long>
    {
        public long NodeId { get; set; }
        public string NodeName { get; set; }
        public string? NodeIndex { get; set; }
        public long ParentId { get; set; }
        public override string ToString()
        {
            return string.Format(@"{{
    ""NodeId"":{0},
    ""NodeName"":""{1}"",
    ""NodeIndex"":""{2}"",
    ""ParentId"":""{3}"",
}}", NodeId
   , NodeName
   , NodeIndex
   , ParentId);
        }
    }
}

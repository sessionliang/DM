using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.CMS
{
    public class CMSInputDtoBase : IInputDto
    {
        public long PublishmentSystemId { get; set; }
    }
}

using Abp.Application.Services.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Sites.Dtos
{
    public class PagedSiteResultRequestDto : PagedResultRequestDto
    {
        public string Keyword { get; set; }
    }
}

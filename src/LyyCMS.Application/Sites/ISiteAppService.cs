using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Sites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Sites
{
    public interface ISiteAppService:
         IAsyncCrudAppService<SiteDto, int, PagedSiteResultRequestDto, CreateSiteDto, SiteDto>
    {

        Task<ListResultDto<SiteDto>> GetAllAsync();
    }
}

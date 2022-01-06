using Abp.Application.Services;
using LyyCMS.Sites.Dtos;

namespace LyyCMS.Sites
{
    public interface ISiteAppService:
         IAsyncCrudAppService<SiteDto, int, PagedSiteResultRequestDto, CreateSiteDto, SiteDto>
    {

        //Task<ListResultDto<SiteDto>> GetAllAsync();
    }
}

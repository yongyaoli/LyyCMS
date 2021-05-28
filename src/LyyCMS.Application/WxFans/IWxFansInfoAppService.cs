using Abp.Application.Services;
using LyyCMS.Articles.Dtos;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;

namespace LyyCMS.WxFans
{
    public interface IWxFansInfoAppService:
        IAsyncCrudAppService<WxFansInfoDto, int, PagedResultReq, CreateWxFansInfoDto, WxFansInfoDto>
    {

        Task<WxFansInfoDto> CreateFansAsync(CreateWxFansInfoDto input);

        Task<PagedResultDto<WxFansInfoDto>> GetFansByAccount(PagedResultReq accountId);
    }
}

using Abp.Application.Services;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;

namespace LyyCMS.WxFans
{
    public interface IWxFansInfoAppService:
        IAsyncCrudAppService<WxFansInfoDto, int, PagedResultRequest, CreateWxFansInfoDto, WxFansInfoDto>
    {
    }
}

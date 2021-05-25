using Abp.Application.Services;
using LyyCMS.Articles.Dtos;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;
using System.Threading.Tasks;

namespace LyyCMS.WxFans
{
    public interface IWxFansInfoAppService:
        IAsyncCrudAppService<WxFansInfoDto, int, PagedResultRequest, CreateWxFansInfoDto, WxFansInfoDto>
    {

        Task<WxFansInfoDto> CreateFansAsync(CreateWxFansInfoDto input);
    }
}

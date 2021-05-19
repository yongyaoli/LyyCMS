using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;

namespace LyyCMS.WxFans
{
    public class WxFansGroupAppService:
        AsyncCrudAppService<WxFansGroup, WxFansGroupDto, int, PagedResultRequest, CreateWxFansGroupDto, WxFansGroupDto>,
        IWxFansGroupAppService
    {
        private readonly IRepository<WxFansGroup> _resposotory;

        public WxFansGroupAppService(IRepository<WxFansGroup> repository) : base(repository)
        {
            _resposotory = repository;
        }
    }
}

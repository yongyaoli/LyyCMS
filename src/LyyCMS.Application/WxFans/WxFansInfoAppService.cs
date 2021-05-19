using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.WxFans
{
    public class WxFansInfoAppService:
        AsyncCrudAppService<WxFansInfo, WxFansInfoDto, int, PagedResultRequest, CreateWxFansInfoDto, WxFansInfoDto>,
        IWxFansInfoAppService
    {
        private readonly IRepository<WxFansInfo> _resposotory;

        public WxFansInfoAppService(IRepository<WxFansInfo> repository) : base(repository)
        {
            _resposotory = repository;
        }
    }
}

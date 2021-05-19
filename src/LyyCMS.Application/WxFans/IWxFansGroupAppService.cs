using Abp.Application.Services;
using LyyCMS.WeChat.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.WxFans.Dto;

namespace LyyCMS.WxFans
{
    public interface IWxFansGroupAppService :
        IAsyncCrudAppService<WxFansGroupDto, int, PagedResultRequest, CreateWxFansGroupDto, WxFansGroupDto>
    {
    }
}

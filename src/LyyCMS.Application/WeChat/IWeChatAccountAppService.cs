using Abp.Application.Services;
using LyyCMS.Members.Dtos;
using LyyCMS.WeChat.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.WeChat
{
    public interface IWeChatAccountAppService :
        IAsyncCrudAppService<WeChatAccountDto, int, PagedResultRequest, WeChatAccountDto, WeChatAccountDto>
    {
    }
}

using System;
using Abp.Application.Services;
using LyyCMS.WeChat.Dto;



namespace LyyCMS.WeChat
{
    public interface IWeChatMenuAppService :
        IAsyncCrudAppService<WeChatMenuDto, int, PagedResultRequest, CreateWxMenuDto, WeChatMenuDto>
    {


    }
}

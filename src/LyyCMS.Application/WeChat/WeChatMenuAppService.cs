using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.WeChat.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.WeChat
{
    public class WeChatMenuAppService:
        AsyncCrudAppService<WeChatMenu, WeChatMenuDto, int, PagedResultRequest, CreateWxMenuDto, WeChatMenuDto>,
        IWeChatMenuAppService
    {
        private readonly IRepository<WeChatMenu> _resposotory;

        public WeChatMenuAppService(IRepository<WeChatMenu> repository) : base(repository)
        {
            _resposotory = repository;
        }
    }
}

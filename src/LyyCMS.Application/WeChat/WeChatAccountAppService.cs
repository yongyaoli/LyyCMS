using Abp.Application.Services;
using LyyCMS.Members.Dtos;
using LyyCMS.Members;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using LyyCMS.WeChat.Dto;

namespace LyyCMS.WeChat
{
    public class WeChatAccountAppService:
        AsyncCrudAppService<WeChatAccount, WeChatAccountDto, int, PagedResultRequest, CreateWxAccountDto, WeChatAccountDto>,
        IWeChatAccountAppService
    {
        private readonly IRepository<WeChatAccount> _resposotory;

        public WeChatAccountAppService(IRepository<WeChatAccount> repository) : base(repository)
        {
            _resposotory = repository;
        }


    }
}

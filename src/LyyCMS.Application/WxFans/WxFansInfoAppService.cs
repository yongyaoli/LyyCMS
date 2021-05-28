using System;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using LyyCMS.WeChat;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Abp.Linq.Extensions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using LyyCMS.Articles.Dtos;
using LyyCMS.Members.Dtos;
using System.Linq.Dynamic.Core;

namespace LyyCMS.WxFans
{
    public class WxFansInfoAppService:
        AsyncCrudAppService<WxFansInfo, WxFansInfoDto, int, PagedResultReq, CreateWxFansInfoDto, WxFansInfoDto>,
        IWxFansInfoAppService
    {
        private readonly IRepository<WxFansInfo> _resposotory;
        private readonly IRepository<WeChatAccount> _accountRepository;

        public WxFansInfoAppService(IRepository<WxFansInfo> repository,IRepository<WeChatAccount> accoutRepository) : base(repository)
        {
            _resposotory = repository;
            _accountRepository = accoutRepository;
        }

        public async Task<WxFansInfoDto> CreateFansAsync(CreateWxFansInfoDto input)
        {
            Logger.Info("start create article");
            var id = input.weChaId;
            var account = _accountRepository.FirstOrDefaultAsync(x => x.Id == id).Result;
            input.weCha = account;
            var dtos = ObjectMapper.Map<WxFansInfo>(input);
            await _resposotory.InsertAsync(dtos);
            return MapToEntityDto(dtos);
        }

        public async Task<PagedResultDto<WxFansInfoDto>> GetFansByAccount(PagedResultReq input)
        {
            int aid = input.AccountId;
            aid = aid < 1 ? 1 : aid;
            var wxAccount = _accountRepository.FirstOrDefaultAsync(x => x.Id == aid).Result;
            var query = _resposotory.GetAll().Where(x=>x.weCha.Equals(wxAccount));
            var personcount = await query.CountAsync();

            var members = await query.OrderBy(input.Sorting).PageBy(input).ToListAsync();
            var dtos = ObjectMapper.Map<List<WxFansInfoDto>>(members);
            var pagedReulstMember = new PagedResultDto<WxFansInfoDto>(personcount, dtos);

            return pagedReulstMember;
        }
    }
}

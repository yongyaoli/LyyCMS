using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Articles;
using LyyCMS.WeChat.Dto;
using LyyCMS.WxFans.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LyyCMS.WeChat;

namespace LyyCMS.WxFans
{
    public class WxFansInfoAppService:
        AsyncCrudAppService<WxFansInfo, WxFansInfoDto, int, PagedResultRequest, CreateWxFansInfoDto, WxFansInfoDto>,
        IWxFansInfoAppService
    {
        private readonly IRepository<WxFansInfo> _resposotory;
        private readonly IRepository<WeChatAccount> _accountRepository;

        public WxFansInfoAppService(IRepository<WxFansInfo> repository,IRepository<WeChatAccount> accoutRepository) : base(repository)
        {
            _resposotory = repository;
            _accountRepository = accoutRepository;
        }

        public async Task<WxFansInfoDto> CreateFasnAsync(CreateWxFansInfoDto input)
        {
            Logger.Info("start create article");
            var id = input.weChaId;
            var account = _accountRepository.FirstOrDefaultAsync(x => x.Id == id).Result;
            input.weCha = account;
            var dtos = ObjectMapper.Map<WxFansInfo>(input);
            await _resposotory.InsertAsync(dtos);
            return MapToEntityDto(dtos);
        }
    }
}

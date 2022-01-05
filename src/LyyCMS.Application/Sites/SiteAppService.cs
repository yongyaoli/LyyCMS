using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.Extensions;
using Abp.IdentityFramework;
using Abp.Linq.Extensions;
using LyyCMS.Sites.Dtos;
using LyyCMS.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace LyyCMS.Sites
{
    public class SiteAppService : AsyncCrudAppService<Site, SiteDto, int, PagedSiteResultRequestDto, CreateSiteDto, SiteDto>, ISiteAppService
    {
        private readonly IRepository<Site> _resposotory;
        private readonly IRepository<Channel> _channelRepository;
        public SiteAppService(IRepository<Site> repository,IRepository<Channel> channelRepository) : base(repository)
        {
            _resposotory= repository;
            _channelRepository= channelRepository;

        }

        public async Task<ListResultDto<SiteDto>> GetAllAsync()
        {
            //var all = await _resposotory.GetAllIncluding(x => x.Channels).ToListAsync();
            var all = await _resposotory.GetAll().ToListAsync();

            return ObjectMapper.Map<ListResultDto<SiteDto>>(all);
        }
    }
}

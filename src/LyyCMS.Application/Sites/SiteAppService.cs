using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Sites.Dtos;
using LyyCMS.Slides;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        

    }
}

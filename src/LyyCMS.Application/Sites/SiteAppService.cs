using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Sites.Dtos;

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

        //public async Task<ListResultDto<SiteDto>> GetAllAsync()
        //{
        //    //var all = await _resposotory.GetAllIncluding(x => x.Channels).ToListAsync();
        //    var all = await _resposotory.GetAll().ToListAsync();

        //    return ObjectMapper.Map<ListResultDto<SiteDto>>(all);
        //}
    }
}

using Abp;
using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Sites.Dtos;
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

        public async Task<SiteDto> UpdateEntryAsync(SiteEditDto input)
        {
            var site = await GetEntityByIdAsync(input.Id);

            ObjectMapper.Map(input, site);

            await _resposotory.UpdateAsync(site);
            return MapToEntityDto(site);

        }

        //public async Task<ListResultDto<SiteDto>> GetAllAsync()
        //{
        //    //var all = await _resposotory.GetAllIncluding(x => x.Channels).ToListAsync();
        //    var all = await _resposotory.GetAll().ToListAsync();

        //    return ObjectMapper.Map<ListResultDto<SiteDto>>(all);
        //}
    }
}

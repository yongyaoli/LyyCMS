using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.Sites.Dtos;

namespace LyyCMS.Sites
{
    public class ChannAppService : AsyncCrudAppService<Channel, ChannelDto, int, PagedSiteResultRequestDto, CreateChannelDto, ChannelDto>, IChannAppService
    {
        private readonly IRepository<Site> _resposotory;
        private readonly IRepository<Channel> _channelRepository;

        public ChannAppService(IRepository<Channel, int> repository) : base(repository)
        {
        }
    }
}

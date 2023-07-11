
using Abp.Application.Services;
using LyyCMS.Sites.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LyyCMS.Sites
{
    public interface IChannAppService : IAsyncCrudAppService<ChannelDto, int, PagedSiteResultRequestDto, CreateChannelDto, ChannelDto>
    {
    }
}

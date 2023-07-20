using Abp.Application.Services;
using LyyCMS.Articles.Dtos;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyyCMS.SysManage
{
    public interface ISysDictItemAppService : IAsyncCrudAppService<SysDictItemDto, int, PagedUserResultRequestDto, CreateSysDictItemDto, SysDictItemDto>
    {

        Task<List<SysDictItemListDto>> GetAllSysDictItemListAsync();

    }
}

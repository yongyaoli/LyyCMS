using Abp.Application.Services;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;

namespace LyyCMS.SysManage
{
    public interface ISysDictItemAppService : IAsyncCrudAppService<SysDictItemDto, int, PagedUserResultRequestDto, CreateSysDictItemDto, SysDictItemDto>
    {
    }
}

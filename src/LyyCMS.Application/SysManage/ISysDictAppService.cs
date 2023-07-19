using Abp.Application.Services;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;

namespace LyyCMS.SysManage
{
    public interface ISysDictAppService : IAsyncCrudAppService<SysDictDto, int, PagedUserResultRequestDto, CreateSysDictDto, SysDictDto>
    {
    }
}

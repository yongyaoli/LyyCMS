using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;

namespace LyyCMS.SysManage
{
    public class SysDictAppService : AsyncCrudAppService<SysDict, SysDictDto, int, PagedUserResultRequestDto, CreateSysDictDto, SysDictDto>, ISysDictAppService
    {
        public SysDictAppService(IRepository<SysDict, int> repository) : base(repository)
        {
        }
    }
}

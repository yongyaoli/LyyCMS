using Abp.Application.Services;
using Abp.Domain.Repositories;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;

namespace LyyCMS.SysManage
{
    public class SysDictItemAppService : AsyncCrudAppService<SysDictItem, SysDictItemDto, int, PagedUserResultRequestDto, CreateSysDictItemDto, SysDictItemDto>, ISysDictItemAppService
    {
        public SysDictItemAppService(IRepository<SysDictItem, int> repository) : base(repository)
        {
        }
    }
}

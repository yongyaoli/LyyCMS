using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LyyCMS.Articles.Dtos;
using LyyCMS.SysManage.Dto;
using LyyCMS.Users.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LyyCMS.SysManage
{
    public interface ISysDictAppService : IAsyncCrudAppService<SysDictDto, int, PagedUserResultRequestDto, CreateSysDictDto, SysDictDto>
    {

        Task<PagedResultDto<SysDictListDto>> GetPagedSysDictAsync(GetSysDictInput input);
    }
}

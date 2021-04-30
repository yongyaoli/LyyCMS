using Abp.Application.Services;
using LyyCMS.MultiTenancy.Dto;

namespace LyyCMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


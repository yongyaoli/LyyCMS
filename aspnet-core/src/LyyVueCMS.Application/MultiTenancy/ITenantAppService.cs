using Abp.Application.Services;
using LyyVueCMS.MultiTenancy.Dto;

namespace LyyVueCMS.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}


using System.Threading.Tasks;
using Abp.Application.Services;
using LyyCMS.Authorization.Accounts.Dto;

namespace LyyCMS.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

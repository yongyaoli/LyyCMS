using System.Threading.Tasks;
using Abp.Application.Services;
using LyyCMS.Sessions.Dto;

namespace LyyCMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

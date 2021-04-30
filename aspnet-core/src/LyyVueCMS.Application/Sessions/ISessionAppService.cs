using System.Threading.Tasks;
using Abp.Application.Services;
using LyyVueCMS.Sessions.Dto;

namespace LyyVueCMS.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}

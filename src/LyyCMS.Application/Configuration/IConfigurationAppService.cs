using System.Threading.Tasks;
using LyyCMS.Configuration.Dto;

namespace LyyCMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

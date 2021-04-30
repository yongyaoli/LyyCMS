using System.Threading.Tasks;
using LyyVueCMS.Configuration.Dto;

namespace LyyVueCMS.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

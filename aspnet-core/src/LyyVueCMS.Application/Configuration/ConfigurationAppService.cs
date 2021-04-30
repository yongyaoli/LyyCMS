using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LyyVueCMS.Configuration.Dto;

namespace LyyVueCMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LyyVueCMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

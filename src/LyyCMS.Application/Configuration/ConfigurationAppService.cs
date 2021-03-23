using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LyyCMS.Configuration.Dto;

namespace LyyCMS.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LyyCMSAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

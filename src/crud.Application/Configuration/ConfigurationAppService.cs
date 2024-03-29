using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using crud.Configuration.Dto;

namespace crud.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : crudAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}

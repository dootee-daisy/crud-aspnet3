using System.Threading.Tasks;
using crud.Configuration.Dto;

namespace crud.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}

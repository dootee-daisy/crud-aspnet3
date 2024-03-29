using System.Threading.Tasks;
using Abp.Application.Services;
using crud.Authorization.Accounts.Dto;

namespace crud.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}

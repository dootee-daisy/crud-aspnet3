using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace crud.Controllers
{
    public abstract class crudControllerBase: AbpController
    {
        protected crudControllerBase()
        {
            LocalizationSourceName = crudConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}

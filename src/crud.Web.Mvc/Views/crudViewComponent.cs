using Abp.AspNetCore.Mvc.ViewComponents;

namespace crud.Web.Views
{
    public abstract class crudViewComponent : AbpViewComponent
    {
        protected crudViewComponent()
        {
            LocalizationSourceName = crudConsts.LocalizationSourceName;
        }
    }
}

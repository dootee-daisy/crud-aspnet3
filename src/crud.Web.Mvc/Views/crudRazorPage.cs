using Abp.AspNetCore.Mvc.Views;
using Abp.Runtime.Session;
using Microsoft.AspNetCore.Mvc.Razor.Internal;

namespace crud.Web.Views
{
    public abstract class crudRazorPage<TModel> : AbpRazorPage<TModel>
    {
        [RazorInject]
        public IAbpSession AbpSession { get; set; }

        protected crudRazorPage()
        {
            LocalizationSourceName = crudConsts.LocalizationSourceName;
        }
    }
}

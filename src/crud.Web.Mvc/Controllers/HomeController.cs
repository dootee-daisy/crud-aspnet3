using Microsoft.AspNetCore.Mvc;
using Abp.AspNetCore.Mvc.Authorization;
using crud.Controllers;

namespace crud.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : crudControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}

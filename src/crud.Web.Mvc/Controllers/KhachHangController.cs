using Abp.AspNetCore.Mvc.Controllers;
using crud.KhachHangs;
using crud.Web.Models.KhachHang;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace crud.Web.Controllers
{
    public class KhachHangController : AbpController
    {
        private readonly KhachHangAppService _khachHangAppservice;
        public KhachHangController(KhachHangAppService khachHangAppservice)
        {
            _khachHangAppservice = khachHangAppservice;
        }
        public async Task<IActionResult> Index()
        {
            var listKhachHang = await _khachHangAppservice.GetAllList();
            var model = listKhachHang.Select(kh => new KhachHangViewModel
            {
                UserName = kh.UserName,
                DisplayName = kh.DisplayName,
                Age = kh.Age,
            }).ToList();
            return View(model);
        }
    }
}

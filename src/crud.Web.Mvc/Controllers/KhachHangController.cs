using Abp.AspNetCore.Mvc.Controllers;
using crud.KhachHangs;
using crud.KhachHangs.DTO;
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
            var model = new KhachHangViewModel
            {
                KhachHangs = listKhachHang.ToList()
            };
            return View(model);
        }
        public async Task<ActionResult> EditModal(string userName)
        {
            var khachHang = await _khachHangAppservice.GetKhachHangByUserName(new GetKhachHangInput(userName));
            var model = new EditKhachHangModalViewModel
            {
                KhachHang = khachHang
            };
            return PartialView("_EditModal", model);
        }
    }
}

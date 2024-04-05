using crud.KhachHangs;
using crud.KhachHangs.DTO;
using System.Collections.Generic;

namespace crud.Web.Models.KhachHang
{
    public class KhachHangViewModel
    {
        public IReadOnlyList<KhachHangDto> KhachHangs { get; set; }
    }
}

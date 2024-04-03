using crud.KhachHangs.DTO;
using System.Collections.Generic;

namespace crud.Web.Models.KhachHang
{
    public class KhachHangViewModel
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
        public long? LastModifierUserId { get; set; }
        public List<GetKhachHangOutput> KhachHangs { get; set; }
    }
}

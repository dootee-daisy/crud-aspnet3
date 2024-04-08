using System;
using System.Collections.Generic;
using System.Text;

namespace crud.KhachHangs.DTO
{
    public class UpdateKhachHangInput
    {
        public string UserName {  get; set; }
        public string DisplayName { get; set; }
        public DateTime NgaySinh { get; set; }
        public long? LastModifierUserId { get; set; }

    }
}

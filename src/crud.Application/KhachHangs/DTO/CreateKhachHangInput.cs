using System;
using System.Collections.Generic;
using System.Text;

namespace crud.KhachHangs.DTO
{
    public class CreateKhachHangInput
    {
        public string UserName { get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
        public DateTime CreationTime { get; set; }

    }
}

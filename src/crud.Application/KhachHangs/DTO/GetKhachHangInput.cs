using System;
using System.Collections.Generic;
using System.Text;

namespace crud.KhachHangs.DTO
{
    public class GetKhachHangInput
    {
        public GetKhachHangInput(string userName)
        {
            UserName = userName;
        }

        public string UserName { get; set; }

    }
}

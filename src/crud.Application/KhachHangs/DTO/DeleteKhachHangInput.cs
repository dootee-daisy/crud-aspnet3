using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace crud.KhachHangs.DTO
{
    public class DeleteKhachHangInput
    {
        [Required]
        public string UserName { get; set; }

    }
}

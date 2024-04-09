using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace crud.KhachHangs.DTO
{
    public class CreateKhachHangInput
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string DisplayName { get; set; }
        [Required]
        public DateTime NgaySinh { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace crud.KhachHangs.DTO
{
    public class SearchKhachHangInput
    {
        public string keyword { get; set; }
        public int? maxResultCount { get; set; }
        public int? skipCount {  get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
    }
}

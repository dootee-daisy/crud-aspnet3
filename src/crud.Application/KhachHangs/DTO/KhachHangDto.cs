using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;


namespace crud.KhachHangs
{
    [AutoMapFrom(typeof(KhachHang))]
    public class KhachHangDto : AuditedEntityDto
    {
        public string UserName {  get; set; }
        public string DisplayName { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}

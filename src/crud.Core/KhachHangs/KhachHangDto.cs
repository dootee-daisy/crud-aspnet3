using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Abp.Domain.Entities.Auditing;


namespace crud.KhachHangs
{
    [AutoMapFrom(typeof(KhachHang))]
    public class KhachHangDto : AuditedEntityDto<string>
    {
        public string UserName {  get; set; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
        public long? LastModifierUserId { get; set; }
    }
}

using Abp.Domain.Entities.Auditing;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace crud.KhachHangs
{
    public class KhachHang : AuditedAggregateRoot
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override int Id { get; set; }
        public string UserName { get; set; }
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        public string DisplayName { get; set; }
        public DateTime NgaySinh { get; set; }
    }
}

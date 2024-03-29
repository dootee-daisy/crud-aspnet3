using Abp.Domain.Entities.Auditing;
using Abp.Events.Bus;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace crud.KhachHangs
{
    public class KhachHang : AuditedAggregateRoot<string>
    {
        [Column("USERNAME")]
        public override string Id { get => base.Id; set => base.Id = value; }
        public override DateTime CreationTime { get => base.CreationTime; set => base.CreationTime = value; }
        public override long? CreatorUserId { get => base.CreatorUserId; set => base.CreatorUserId = value; }
        public override DateTime? LastModificationTime { get => base.LastModificationTime; set => base.LastModificationTime = value; }
        public override long? LastModifierUserId { get => base.LastModifierUserId; set => base.LastModifierUserId = value; }
        public string DisplayName { get; set; }
        public int Age { get; set; }
    }
}

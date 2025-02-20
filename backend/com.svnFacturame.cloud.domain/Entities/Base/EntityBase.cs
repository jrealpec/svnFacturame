using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using com.svnFacturame.cloud.domain.Interfaces.Management;

namespace com.svnFacturame.cloud.domain.Entities.Base
{
    public abstract class EntityBase<TKey> : IEntityBase<TKey>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public TKey Id { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
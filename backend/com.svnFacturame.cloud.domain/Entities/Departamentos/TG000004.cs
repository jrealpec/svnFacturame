using com.svnFacturame.cloud.domain.Entities.Base;
using com.svnFacturame.cloud.domain.Entities.Ciudades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.Departamentos
{
    [Table("TG000004")]
    public class TG000004 : EntityBase<TG000004>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string CodDepto { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public virtual ICollection<TG000002> _TG000002 { get; set; }
    }
}

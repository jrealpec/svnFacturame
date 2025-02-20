using com.svnFacturame.cloud.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.CIE
{
    [Table("TB000001")]
    public class TB000001 : EntityBase<TB000001>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(6)]
        public string Clave { get; set; }
        [Required]
        [StringLength(256)]
        public string Name { get; set; }
        public virtual ICollection<TB000002> _TB000002 { get; set; }

    }
}

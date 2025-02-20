using com.svnFacturame.cloud.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.CIE
{
    [Table("TB000002")]
    public class TB000002 : EntityBase<TB000002>
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
        public int idGrupo { get; set; }
        public TB000001 _TB000001 { get; set; }
    }
}

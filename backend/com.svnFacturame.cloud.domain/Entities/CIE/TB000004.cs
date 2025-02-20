using com.svnFacturame.cloud.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.CIE
{
    [Table("TB000004")]
    public class TB000004:EntityBase<TB000004>
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
        public int idCategoria { get; set; }
    }
}

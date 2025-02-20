using com.svnFacturame.cloud.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.Bancos

{
    [Table("TG000001")]
    public class TG000001:EntityBase<TG000001>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Column("Cod_Banco")]
        [StringLength(50)]
        public string CodBanco { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}

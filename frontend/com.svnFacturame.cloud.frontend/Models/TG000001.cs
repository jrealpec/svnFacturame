using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace com.svnFacturame.cloud.frontend.core.Models
{
    [Table("TG000001")]
    public class TG000001
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Column("Cod_Banco")]
        [StringLength(50)]
        public string CodBanco { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

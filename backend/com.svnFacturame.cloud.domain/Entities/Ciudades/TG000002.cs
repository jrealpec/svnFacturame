using com.svnFacturame.cloud.domain.Entities.Base;
using com.svnFacturame.cloud.domain.Entities.Departamentos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.Ciudades

{
    [Table("TG000002")]
    public class TG000002:EntityBase<TG000002>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string CodCiudad { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        public int? IdDeptoCiud {  get; set; }
        public TG000004 _TG000004 { get; set; }
    }
}

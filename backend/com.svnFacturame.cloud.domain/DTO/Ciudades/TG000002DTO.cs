using com.svnFacturame.cloud.domain.Entities.Departamentos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace com.svnFacturame.cloud.domain.DTO.Ciudades
{
    [Table("TG000002")]
    public class TG000002DTO
    {
        public string CodCiudad { get; set; }
        [ForeignKey("IdDeptoCiud")]
        public int? IdDeptoCiud { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

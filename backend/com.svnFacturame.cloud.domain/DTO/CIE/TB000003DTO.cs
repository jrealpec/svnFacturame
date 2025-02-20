using System;


#nullable disable

namespace com.svnFacturame.cloud.domain.DTO.CIE
{
    public class TB000003DTO
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Name { get; set; }
        public Int32 idSubGrupo { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

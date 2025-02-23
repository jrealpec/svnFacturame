using com.svnFacturame.cloud.domain.Entities.Ciudades;
using System;
using System.Collections.Generic;


namespace com.svnFacturame.cloud.domain.DTO.Departamentos
{
    public class TG000004DTO
    {
        public int Id { get; set; }
        public string CodDepto { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<TG000002> _TG000002 { get; set; } = new List<TG000002>();
    }
}

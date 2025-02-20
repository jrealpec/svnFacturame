using com.svnFacturame.cloud.domain.Entities.CIE;
using System;
using System.Collections.Generic;


#nullable disable

namespace com.svnFacturame.cloud.domain.DTO.CIE
{
    public class TB000001DTO
    {
        public int Id { get; set; }
        public string Clave { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        public List<TB000002> _TB000002 { get; set; } = new List<TB000002>();
    }
}

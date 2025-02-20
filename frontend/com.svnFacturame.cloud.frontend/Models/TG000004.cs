using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace com.svnFacturame.cloud.frontend.core.Models
{
    public class TG000004
    {
        [Key]
        public int Id { get; set; }
        public string CodDepto { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public List<TG000002> _TG000002 { get; set; } = new List<TG000002>();
    }
}

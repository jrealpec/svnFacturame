using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace com.svnFacturame.cloud.frontend.core.Models
{
    public class TG000002
    {
        [Key]
        public long Id { get; set; }
        public string CodCiudad { get; set; }
        public Int32 IdDeptoCiud { get; set; }
        public string Name { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

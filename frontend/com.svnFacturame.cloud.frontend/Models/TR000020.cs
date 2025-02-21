using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace com.svnFacturame.cloud.frontend.core.Models
{
    [Table("TR000020")]
    public class TR000020
    {
        [Key]
        public int Id { get; set; }
        public string Numero { get; set; }
        public string NumeroDoc { get; set; }
        public string Nombre { get; set; }
        public int Monto { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

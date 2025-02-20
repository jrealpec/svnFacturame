using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace com.svnFacturame.cloud.frontend.core.Models
{
    public class TS000001
    {
        public int Nivel { get; set; }
        public string Cod_Modulo { get; set; }
        public string Des_Modulo { get; set; }
        public int Cod_NPadre { get; set; }
        public int Cod_PadrePrincipal { get; set; }
        public bool Mod_Progra { get; set; }
        public bool Mod_principal { get; set; }
        public string Controller_Name { get; set; }
        public string Action_Name { get; set; }
        public string NombreImage { get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

using com.svnFacturame.cloud.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.Menu
{
    [Table("TS000001")]
    public class TS000001 : EntityBase<TS000001>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Nivel { get; set; }
        public string Cod_Modulo { get; set; }
        public string Des_Modulo { get; set; }
        public int Cod_NPadre { get; set; }
        public int Cod_PadrePrincipal { get; set; }
        public bool Mod_Progra {  get; set; }
        public bool Mod_principal { get; set; }
        public string Controller_Name { get; set; }
        public string Action_Name { get; set;}
        public string NombreImage { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using com.svnFacturame.cloud.domain.Entities.Base;


namespace com.svnFacturame.cloud.domain.Entities.Facturas
{
    public class TR000020:EntityBase<TR000020>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Numero { get; set; }
        public string NumeroDoc { get; set; }
        public string Nombre { get; set; }
        public int Monto { get; set; }
    }
}

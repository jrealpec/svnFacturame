using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace com.svnFacturame.cloud.frontend.core.Models
{
    [Table("TR000010")]
    public class TR000010
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [Column("Cod_Banco")]
        [StringLength(50)]
        public string CodBanco { get; set; }
        public string NumRadicado { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        public Int32 ID_TS_ESTADO { get; set; }
        public string Name_TS_ESTADO { get; set; }
        public Int32 QtyDias { get; set; }
        public DateTime FechaIni {  get; set; }
        public DateTime FechaFin {  get; set; }
        [DataType(DataType.MultilineText)]
        public string Detalle {  get; set; }
        public string Observaciones { get; set; }
        public Boolean Status { get; set; }
        public bool? Visible { get; set; }
        public long? CreatedBy { get; set; }
        public string Name_CreatedBy { get; set; }
        public string Name_Usuario { get; set; }
        public string Name_Cargo { get; set; }
        public string Name_Dependencia { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ListaVentanilla
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaClaseDocumentos
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaTipoDocumentos
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaMotivoDocumentos
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaPaises
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaDepartamentos
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaCiudades
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaTipoRemision
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaDependientes
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaCotizantes
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaGrupoCIE10
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaSubGrupoCIE10
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaCategoriasCIE10
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
    public class ListaDiagnosticosCIE10
    {
        public int ID { get; set; }
        public string NOMBRE { get; set; }
    }
}

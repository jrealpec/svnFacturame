using com.svnFacturame.cloud.domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace com.svnFacturame.cloud.domain.Entities.Empresas

{
    [Table("TG000003")]
    public class TG000003:EntityBase<TG000003>
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string IdEmpresaPrincipal { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        public string SiglasEmpresa { get; set; }
        public string DireccionEmpresa { get; set; }
        public string NomRegistroPilaEmpresa { get; set; }
        public string TipoAportanteEmpresa { get; set; }
        public string NitEmpresaAdmin { get; set; }
        public int DVEmpresaAdmin { get; set; }
        public int IdTipoDocumentoEmpAdm { get; set; }
        public int IdDeptoEmpAdm { get; set; }
        public int IdCiudadEmpAdm { get; set; }
        public string TelEmpAdm { get; set; }
        public string CelularEmpAdm { get; set; }
        public string EmailEmpAdm { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Val_AdmonGEmpAdm { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorcEps { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorAFP { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorcCaja { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorcSena { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorcICBF { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Riesgo1 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Riesgo2 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Riesgo3 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Riesgo4 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Riesgo5 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorMoraPlanilla { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? PorMoraRecibo { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? ValorMensajeriaRecibo { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? ValorReactivacion { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? ValorRetiro { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? De4amenosde16 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? De16hasta17 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Masde17hasta18 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Masde18hasta19 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Masde19hasta20 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Mayora20 { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? IBCredondeado { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? IBCresiduoMayor { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? Cotizacionredondeada { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? CotizacionresiduoMayor { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? IBCnoCaja { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? CotizacionnoCaja { get; set; }
        [Column(TypeName = "decimal(18,0)")]
        public decimal? AdmoGrabada { get; set; }
        public DateTime? Fecha_PrimerPago { get; set; }
        public DateTime? Fecha_SegundoPago { get; set; }
        public string Despedida { get; set; }
        public string DepartamentoCargo { get; set; }
        public string FirmadaPor { get; set; }
        public Boolean PagaMesActual { get; set; }
        public Boolean IvaIncluido { get; set; }
        public Boolean GrabarReal { get; set; }
    }
}

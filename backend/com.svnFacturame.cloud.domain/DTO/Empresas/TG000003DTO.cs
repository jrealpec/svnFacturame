using System;
using System.Collections.Generic;
using System.Text;

namespace com.svnFacturame.cloud.domain.DTO.Empresas
{
    public class TG000003DTO
    {
        public int Id { get; set; }
        public string IdEmpresaPrincipal { get; set; }
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
        public decimal Val_AdmonGEmpAdm { get; set; }
        public decimal PorcEps { get; set; }
        public decimal PorAFP { get; set; }
        public decimal PorcCaja { get; set; }
        public decimal PorcSena { get; set; }
        public decimal PorcICBF { get; set; }
        public decimal Riesgo1 { get; set; }
        public decimal Riesgo2 { get; set; }
        public decimal Riesgo3 { get; set; }
        public decimal Riesgo4 { get; set; }
        public decimal Riesgo5 { get; set; }
        public decimal PorMoraPlanilla { get; set; }
        public decimal PorMoraRecibo { get; set; }
        public decimal ValorMensajeriaRecibo { get; set; }
        public decimal ValorReactivacion { get; set; }
        public decimal ValorRetiro { get; set; }
        public decimal De4amenosde16 { get; set; }
        public decimal De16hasta17 { get; set; }
        public decimal Masde17hasta18 { get; set; }
        public decimal Masde18hasta19 { get; set; }
        public decimal Masde19hasta20 { get; set; }
        public decimal Mayora20 { get; set; }
        public decimal IBCredondeado { get; set; }
        public decimal IBCresiduoMayor { get; set; }
        public decimal Cotizacionredondeada { get; set; }
        public decimal CotizacionresiduoMayor { get; set; }
        public decimal IBCnoCaja {  get; set; }
        public decimal CotizacionnoCaja { get; set; }
        public decimal AdmoGrabada { get; set; }
        public DateTime Fecha_PrimerPago { get; set; }
        public DateTime Fecha_SegundoPago { get; set; }
        public string Despedida { get; set; }
        public string DepartamentoCargo { get; set; }
        public string FirmadaPor {  get; set; }
        public Boolean PagaMesActual {  get; set; }
        public Boolean IvaIncluido { get; set; }
        public Boolean GrabarReal {  get; set; }
        public bool? Status { get; set; }
        public bool? Visible { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreationDate { get; set; }
        public int? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}

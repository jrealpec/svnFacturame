
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using com.svnFacturame.cloud.frontend.core.Models;

namespace com.svnFacturame.cloud.frontend.core.Controllers
{
    public class TR000010Controller : gcBaseController
    {
        private HttpClient TR000010Api = new HttpClient();
        List<ListaVentanilla> lstVentanilla = new List<ListaVentanilla>();
        List<ListaPaises> lstPaises = new List<ListaPaises>();
        List<ListaDepartamentos> lstDepto = new List<ListaDepartamentos>();
        List<ListaCiudades> lstCiudades = new List<ListaCiudades>();
        List<ListaDependientes> lstDependientes = new List<ListaDependientes>();
        List<ListaCotizantes> lstCotizantes = new List<ListaCotizantes>();
        List<ListaClaseDocumentos> lstClaseDocumentos = new List<ListaClaseDocumentos>();
        List<ListaTipoDocumentos> lstTipoDocumentos = new List<ListaTipoDocumentos>();
        List<ListaMotivoDocumentos> lstMotivoDocumentos = new List<ListaMotivoDocumentos>();
        List<ListaTipoRemision> lstTipoRemision = new List<ListaTipoRemision>();
        List<ListaGrupoCIE10> lstGrupoCIE10 = new List<ListaGrupoCIE10>();
        List<ListaSubGrupoCIE10> lstSubGrupoCIE10 = new List<ListaSubGrupoCIE10>();
        List<ListaCategoriasCIE10> lstCategoriasCIE10 = new List<ListaCategoriasCIE10>();
        List<ListaDiagnosticosCIE10> lstDiagnosticosCIE10 = new List<ListaDiagnosticosCIE10>();

        public TR000010Controller()
        {
            TR000010Api.BaseAddress = new Uri("http://localhost:10263");
        }

        public ActionResult Create()
        {
            TR000010 tr000010Model = new TR000010();
            lstVentanilla = new List<ListaVentanilla>(){
                new ListaVentanilla {
                                    ID=1,
                                    NOMBRE = "Principal"
                },
                new ListaVentanilla {
                                    ID=2,
                                    NOMBRE = "Sucursal 1"
                },
                new ListaVentanilla {
                                    ID=3,
                                    NOMBRE = "Sucursal 2"
                }
            };
            lstClaseDocumentos = new List<ListaClaseDocumentos>(){
                new ListaClaseDocumentos {
                                    ID=1,
                                    NOMBRE = "Entrada"
                },
                new ListaClaseDocumentos {
                                    ID=2,
                                    NOMBRE = "Salida"
                }
            };
            lstTipoDocumentos = new List<ListaTipoDocumentos>(){
                new ListaTipoDocumentos {
                                    ID=1,
                                    NOMBRE = "Enfermedad General"
                },
                new ListaTipoDocumentos {
                                    ID=2,
                                    NOMBRE = "Enfermedad Profesional/laboral"
                }
            };
            lstMotivoDocumentos = new List<ListaMotivoDocumentos>(){
                new ListaMotivoDocumentos {
                                    ID=1,
                                    NOMBRE = "Intoxicación"
                },
                new ListaMotivoDocumentos {
                                    ID=2,
                                    NOMBRE = "Accidente tránsito"
                },
                new ListaMotivoDocumentos {
                                    ID=3,
                                    NOMBRE = "Ataque arma cortopunzante"
                }
            };
            lstPaises = new List<ListaPaises>(){
                new ListaPaises {
                                    ID=1,
                                    NOMBRE = "Colombia"
                },
                new ListaPaises {
                                    ID=2,
                                    NOMBRE = "E.E.U.U."
                },
                new ListaPaises {
                                    ID=3,
                                    NOMBRE = "PERU"
                }
            };
            lstDepto = new List<ListaDepartamentos>(){
                new ListaDepartamentos {
                                    ID=1,
                                    NOMBRE = "Valle del Cauca"
                },
                new ListaDepartamentos {
                                    ID=2,
                                    NOMBRE = "Cundinamarca"
                },
                new ListaDepartamentos {
                                    ID=3,
                                    NOMBRE = "Boyaca"
                }
            };
            lstCiudades = new List<ListaCiudades>(){
                new ListaCiudades {
                                    ID=1,
                                    NOMBRE = "Santiago de Cali"
                },
                new ListaCiudades {
                                    ID=2,
                                    NOMBRE = "Guadalajara de Buga"
                },
                new ListaCiudades {
                                    ID=3,
                                    NOMBRE = "Palmira"
                }
            };
            lstTipoRemision = new List<ListaTipoRemision>(){
                new ListaTipoRemision {
                                    ID=1,
                                    NOMBRE = "Ambulatoria"
                },
                new ListaTipoRemision {
                                    ID=2,
                                    NOMBRE = "Mas de 2 dias"
                },
                new ListaTipoRemision {
                                    ID=3,
                                    NOMBRE = "Mas de 6 meses"
                }
            };
            lstDependientes = new List<ListaDependientes>(){
                new ListaDependientes {
                                    ID=1,
                                    NOMBRE = "EPS SURA"
                },
                new ListaDependientes {
                                    ID=2,
                                    NOMBRE = "NUEVA EPS"
                },
                new ListaDependientes {
                                    ID=3,
                                    NOMBRE = "SALUD TOTAL"
                }
            };
            lstCotizantes = new List<ListaCotizantes>(){
                new ListaCotizantes {
                                    ID=1,
                                    NOMBRE = "Adalberto Garcia"
                },
                new ListaCotizantes {
                                    ID=2,
                                    NOMBRE = "Diana Lorena Munera"
                },
                new ListaCotizantes {
                                    ID=3,
                                    NOMBRE = "Betty Fantoche"
                }
            };
            lstGrupoCIE10 = new List<ListaGrupoCIE10>(){
                new ListaGrupoCIE10 {
                                    ID=1,
                                    NOMBRE = "Ciertas enfermedades infecciosas y parasitarias"
                },
                new ListaGrupoCIE10 {
                                    ID=2,
                                    NOMBRE = "Neoplasias"
                },
                new ListaGrupoCIE10 {
                                    ID=3,
                                    NOMBRE = "Enfermedades de la sangre y de los organos hematopoyeticos y otros trastornos que afectan el mecanismo de la inmunidad"
                }
            };
            lstSubGrupoCIE10 = new List<ListaSubGrupoCIE10>(){
                new ListaSubGrupoCIE10 {
                                    ID=1,
                                    NOMBRE = "Enfermedades infecciosas intestinales"
                },
                new ListaSubGrupoCIE10 {
                                    ID=2,
                                    NOMBRE = "Fiebres virales trasmitidas por artrópodos y fiebres virales hemorrágicas"
                },
                new ListaSubGrupoCIE10 {
                                    ID=3,
                                    NOMBRE = "Infecciones virales caracterizadas por lesiones de la piel y de las membranas mucosas"
                }
            };
            lstCategoriasCIE10 = new List<ListaCategoriasCIE10>(){
                new ListaCategoriasCIE10 {
                                    ID=1,
                                    NOMBRE = "Cólera"
                },
                new ListaCategoriasCIE10 {
                                    ID=2,
                                    NOMBRE = "Fiebres tifoidea y paratifoidea"
                },
                new ListaCategoriasCIE10 {
                                    ID=3,
                                    NOMBRE = "Otras infecciones debidas a Salmonella"
                }
            };
            lstDiagnosticosCIE10 = new List<ListaDiagnosticosCIE10>(){
                new ListaDiagnosticosCIE10 {
                                    ID=1,
                                    NOMBRE = "Colera debido a vibrio cholerae o1, biotipo cholerae"
                },
                new ListaDiagnosticosCIE10 {
                                    ID=2,
                                    NOMBRE = "Fiebre tifoidea"
                },
                new ListaDiagnosticosCIE10 {
                                    ID=3,
                                    NOMBRE = "Enteritis debida a salmonella"
                }
            };
            ViewBag.ListaVentanillas = lstVentanilla;
            ViewBag.ListaClaseDocumentos = lstClaseDocumentos;
            ViewBag.ListaTipoDocumentos = lstTipoDocumentos;
            ViewBag.ListaMotivoDocumentos = lstMotivoDocumentos;
            ViewBag.ListaPaises = lstPaises;
            ViewBag.ListaDepto = lstDepto;
            ViewBag.ListaCiudades = lstCiudades;
            ViewBag.ListaTipoRemision = lstTipoRemision;
            ViewBag.ListaDependientes = lstDependientes;
            ViewBag.ListaCotizantes = lstCotizantes;
            ViewBag.ListaGrupoCIE10 = lstGrupoCIE10;
            ViewBag.ListaSubGrupoCIE10 = lstSubGrupoCIE10;
            ViewBag.ListaCategoriasCIE10 = lstCategoriasCIE10;
            ViewBag.ListaDiagnosticosCIE10 = lstDiagnosticosCIE10;
            TR000010 model = new TR000010();
            tr000010Model.Status = false;
            tr000010Model.ID_TS_ESTADO = 2;
            tr000010Model.NumRadicado = "1241020002444";
            tr000010Model.Name_TS_ESTADO = "Radicado";
            tr000010Model.Name_Usuario = "jrealpec@hotmail.com";
            tr000010Model.Name_CreatedBy = "Juan E. Realpe";
            tr000010Model.CreationDate = DateTime.Now;
            tr000010Model.Name_Cargo = "Analista";
            tr000010Model.Name_Dependencia = "Gestion de Incapacidades";
            model.Status = tr000010Model.Status;
            model.ID_TS_ESTADO = tr000010Model.ID_TS_ESTADO;
            model.NumRadicado = tr000010Model.NumRadicado;
            model.Name_TS_ESTADO = tr000010Model.Name_TS_ESTADO;
            model.Name_CreatedBy = tr000010Model.Name_CreatedBy;
            model.Name_Usuario = tr000010Model.Name_Usuario;
            model.CreationDate = tr000010Model.CreationDate;
            model.Name_Cargo = tr000010Model.Name_Cargo;
            model.Name_Dependencia = tr000010Model.Name_Dependencia;
            return View(model);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(TR000010 newTR000010)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        string newuserdata = JsonConvert.SerializeObject(newTR000010);
        //        var TR000010data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
        //        HttpResponseMessage apiresponse = TR000010Api.PostAsync("api/TR000010", TR000010data).Result;
        //        ViewBag.message = apiresponse.Content.ReadAsStringAsync().Result;
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

    }
}

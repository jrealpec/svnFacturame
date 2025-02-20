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
using com.svnFacturame.cloud.frontend.core.ViewModel;
using System.Xml.Linq;

namespace com.svnFacturame.cloud.frontend.core.Controllers.Menu
{
    public class TS000001Controller : gcBaseController{
        private HttpClient ts000001Api = new HttpClient();
        public TS000001Controller()
        {
            ts000001Api.BaseAddress = new Uri("http://localhost:10263");
        }

        public ActionResult GetMenu()
        {
            //ViewBag.MenuList = this.cargarMenu();
            return View("_Sidebar", this.cargarMenu());
        }
        private List<TS000001> cargarMenu()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            ts000001Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = ts000001Api.GetAsync("api/TS000001").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TS000001> TS000001List = JsonConvert.DeserializeObject<List<TS000001>>(respondsdata);
            return TS000001List;
        }
        public MenuViewModel getMenu()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            ts000001Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = ts000001Api.GetAsync("api/TS000001").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TS000001> TS000001List = JsonConvert.DeserializeObject<List<TS000001>>(respondsdata);
            MenuViewModel _menuViewModel = new MenuViewModel();
            _menuViewModel.elements = new List<MenuElement>();
            for (int i = 0; i < TS000001List.Count; i++)
            {
                MenuElement element = new MenuElement();
                element.Cod_Modulo = TS000001List[i].Cod_Modulo;
                element.Des_Modulo = TS000001List[i].Des_Modulo;
                element.Nivel = TS000001List[i].Nivel;
                element.children = new List<MenuElement>();
                element.Cod_NPadre = TS000001List[i].Cod_NPadre;
                int codPadre = element.Cod_NPadre;
                string URL = "/api/TS000001/GetTS000001CodNPadre?CodNPadre=" + codPadre;
                HttpResponseMessage apiresponseChildren = ts000001Api.GetAsync(URL).Result;
                string respondsdataChildren = apiresponseChildren.Content.ReadAsStringAsync().Result;
                List<TS000001> TS000001ListChildren = JsonConvert.DeserializeObject<List<TS000001>>(respondsdataChildren);
                if (TS000001ListChildren != null)
                {
                    for (int j = 0; j < TS000001ListChildren.Count; j++)
                    {
                        //if (TS000001ListChildren[j].Cod_NPadre == TS000001List[i].Nivel)
                        //{
                            MenuElement element2 = new MenuElement();
                            element2.Cod_Modulo = TS000001List[j].Cod_Modulo;
                            element2.Des_Modulo = TS000001List[j].Des_Modulo;
                            element2.Action_Name = TS000001List[j].Action_Name;
                            element2.Controller_Name = TS000001List[j].Controller_Name;
                            element.children.Add(element2);
                        //}
                    }
                }
                _menuViewModel.elements.Add(element);
            }
            return _menuViewModel;
        }
    }
}

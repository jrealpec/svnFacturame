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
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace com.svnFacturame.cloud.frontend.core.Controllers.Ciudades
{
    public class TG000002Controller : gcBaseController
    {
        private HttpClient tg00002Api = new HttpClient();
        private HttpClient tg000004Api = new HttpClient();
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public TG000002Controller()
        {
            tg00002Api.BaseAddress = new Uri("http://localhost:10263");
            tg000004Api.BaseAddress = new Uri("http://localhost:10263");
        }
        public ActionResult Index()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            tg00002Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = tg00002Api.GetAsync("api/TG000002").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TG000002> TG000002List = JsonConvert.DeserializeObject<List<TG000002>>(respondsdata);

            return View(TG000002List.ToList());
        }
        public ActionResult Create()
        {
            List<TG000004> TG000004List = this.cargarDepto();
            ViewBag.lstTG000004 = TG000004List;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TG000002 newTG000002)
        {
            try
            {
                // TODO: Add insert logic here
                if (User.Identity.IsAuthenticated){
                   var _user= _userManager.FindByEmailAsync(User.Identity.Name.ToString());
                }
                newTG000002.CreationDate = DateTime.Now;
                newTG000002.UpdateDate = null;
                string newuserdata = JsonConvert.SerializeObject(newTG000002);
                var TG000002data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tg00002Api.PostAsync("api/TG000002", TG000002data).Result;
                ViewBag.message = apiresponse.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            List<TG000004> TG000004List = this.cargarDepto();
            ViewBag.lstTG000004 = TG000004List;
            if (User.Identity.IsAuthenticated)
            {
                var _user = _signInManager.UserManager.FindByEmailAsync(User.Identity.Name.ToString());
            }
            HttpResponseMessage apiresponse = tg00002Api.GetAsync("/api/TG000002/" + id).Result;
            string _TG000002data = apiresponse.Content.ReadAsStringAsync().Result;
            TG000002 _TG000002toedit = JsonConvert.DeserializeObject<TG000002>(_TG000002data);

            return View(_TG000002toedit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, TG000002 _TG000002edit)
        {
            try
            {
                // TODO: Add update logic here
                _TG000002edit.UpdateDate = DateTime.Now;
                string newuserdata = JsonConvert.SerializeObject(_TG000002edit);
                var _TG000002data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tg00002Api.PutAsync("/api/TG000002/" + _TG000002edit.Id, _TG000002data).Result;
                ViewBag.message = apiresponse.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private List<TG000004> cargarDepto()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            tg000004Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = tg000004Api.GetAsync("api/TG000004").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TG000004> TG000004List = JsonConvert.DeserializeObject<List<TG000004>>(respondsdata);
            return TG000004List;
        }
    }
}

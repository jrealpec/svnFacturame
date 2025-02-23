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

namespace com.svnFacturame.cloud.frontend.core.Controllers.Departamentos
{
    public class TG000004Controller : gcBaseController
    {
        private HttpClient tg000004Api = new HttpClient();
        public TG000004Controller()
        {
            tg000004Api.BaseAddress = new Uri("http://localhost:10263");

        }
        public ActionResult Index()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            tg000004Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = tg000004Api.GetAsync("api/TG000004").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TG000004> TG000004List = JsonConvert.DeserializeObject<List<TG000004>>(respondsdata);

            return View(TG000004List.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TG000004 newTG000004)
        {
            try
            {
                newTG000004.UpdateDate = null;
                string newuserdata = JsonConvert.SerializeObject(newTG000004);
                var TG000004data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tg000004Api.PostAsync("api/TG000004", TG000004data).Result;
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
            HttpResponseMessage apiresponse = tg000004Api.GetAsync("/api/TG000004/" + id).Result;
            string _TG000004data = apiresponse.Content.ReadAsStringAsync().Result;
            TG000004 _TG000004toedit = JsonConvert.DeserializeObject<TG000004>(_TG000004data);

            return View(_TG000004toedit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, TG000004 _TG000004edit)
        {
            try
            {
                // TODO: Add update logic here
                _TG000004edit.UpdateDate = DateTime.Now;
                string newuserdata = JsonConvert.SerializeObject(_TG000004edit);
                var _TG000004data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tg000004Api.PutAsync("/api/TG000004/" + _TG000004edit.Id, _TG000004data).Result;
                ViewBag.message = apiresponse.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

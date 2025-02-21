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

namespace com.svnFacturame.cloud.frontend.core.Controllers.Bancos
{
    public class TG000001Controller : gcBaseController
    {
        private HttpClient tg00001Api = new HttpClient();

        public TG000001Controller()
        {
            tg00001Api.BaseAddress = new Uri("http://localhost:10263");
        }

        //GET TG000001
        public ActionResult Index()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            tg00001Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = tg00001Api.GetAsync("api/TG000001").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TG000001> TG000001List = JsonConvert.DeserializeObject<List<TG000001>>(respondsdata);

            return View(TG000001List.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TG000001 newTG000001)
        {
            try
            {
                // TODO: Add insert logic here
                string newuserdata = JsonConvert.SerializeObject(newTG000001);
                var TG000001data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tg00001Api.PostAsync("api/TG000001", TG000001data).Result;
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
            HttpResponseMessage apiresponse = tg00001Api.GetAsync("/api/TG000001/" + id).Result;
            string _TG000001data = apiresponse.Content.ReadAsStringAsync().Result;
            TG000001 _TG000001toedit = JsonConvert.DeserializeObject<TG000001>(_TG000001data);

            return View(_TG000001toedit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, TG000001 _TG000001edit)
        {
            try
            {
                // TODO: Add update logic here
                string newuserdata = JsonConvert.SerializeObject(_TG000001edit);
                var _TG000001data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tg00001Api.PutAsync("/api/TG000001/" + _TG000001edit.Id, _TG000001data).Result;
                ViewBag.message = apiresponse.Content.ReadAsStringAsync().Result;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage apiresponse = tg00001Api.GetAsync("/api/TG000001/" + id).Result;
            string _TG000001data = apiresponse.Content.ReadAsStringAsync().Result;
            TG000001 _TG000001ToDelete = JsonConvert.DeserializeObject<TG000001>(_TG000001data);

            return View(_TG000001ToDelete);
        }

        // POST: TG000001/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                HttpResponseMessage apiresponse = tg00001Api.DeleteAsync("/api/TG000001/" + id).Result;
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

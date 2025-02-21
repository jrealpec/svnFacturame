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

namespace com.svnFacturame.cloud.frontend.core.Controllers.Facturas
{
    public class TR000020Controller : gcBaseController
    {

        private HttpClient tr000020Api = new HttpClient();

        public TR000020Controller()
        {
            tr000020Api.BaseAddress = new Uri("http://localhost:10263");

        }

        public ActionResult Index()
        {
            MediaTypeWithQualityHeaderValue contenType = new MediaTypeWithQualityHeaderValue("application/Json");
            tr000020Api.DefaultRequestHeaders.Accept.Add(contenType);
            HttpResponseMessage apiresponse = tr000020Api.GetAsync("api/TR000020").Result;
            string respondsdata = apiresponse.Content.ReadAsStringAsync().Result;
            List<TR000020> TR000020List = JsonConvert.DeserializeObject<List<TR000020>>(respondsdata);

            return View(TR000020List.ToList());
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TR000020 newTR000020)
        {
            try
            {
                // TODO: Add insert logic here
                string newuserdata = JsonConvert.SerializeObject(newTR000020);
                var TR000020data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tr000020Api.PostAsync("api/TR000020", TR000020data).Result;
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
            HttpResponseMessage apiresponse = tr000020Api.GetAsync("/api/TR000020/" + id).Result;
            string _TR000020data = apiresponse.Content.ReadAsStringAsync().Result;
            TR000020 _TR000020toedit = JsonConvert.DeserializeObject<TR000020>(_TR000020data);

            return View(_TR000020toedit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, TR000020 _TR000020edit)
        {
            try
            {
                // TODO: Add update logic here
                string newuserdata = JsonConvert.SerializeObject(_TR000020edit);
                var _TR000020data = new StringContent(newuserdata, System.Text.Encoding.UTF8, "application/Json");
                HttpResponseMessage apiresponse = tr000020Api.PutAsync("/api/TR000020/" + _TR000020edit.Id, _TR000020data).Result;
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
            HttpResponseMessage apiresponse = tr000020Api.GetAsync("/api/TR000020/" + id).Result;
            string _TR000020data = apiresponse.Content.ReadAsStringAsync().Result;
            TR000020 _TR000020ToDelete = JsonConvert.DeserializeObject<TR000020>(_TR000020data);

            return View(_TR000020ToDelete);
        }

        // POST: TR000020/Delete/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                HttpResponseMessage apiresponse = tr000020Api.DeleteAsync("/api/TR000020/" + id).Result;
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

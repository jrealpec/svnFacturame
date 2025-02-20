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
    }
}

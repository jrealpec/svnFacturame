using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;

namespace com.svnFacturame.cloud.frontend.core.Controllers
{
    public abstract class gcBaseController : Controller
    {
        public IConfigurationRoot configuration;
        //public IActionResult Index()
        //{
        //    return View();
        //}
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            configuration = new ConfigurationBuilder()
                           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                           .AddJsonFile("appsettings.json")
                           .Build();
            ViewBag._SiteVersion = configuration.GetValue<string>("SiteVersion");
            ViewBag._SiteName = configuration.GetValue<string>("SiteName");
            ViewBag._SiteOwner = configuration.GetValue<string>("SiteOwner");
            ViewBag._SiteDeveloper = configuration.GetValue<string>("SiteDeveloper");
            ViewBag._SiteDeveloperUrl = configuration.GetValue<string>("SiteDeveloperUrl");
            ViewBag._SiteDeveloperSupport = configuration.GetValue<string>("SiteDeveloperSupport");
            ViewBag._SiteDeveloperSupportText = configuration.GetValue<string>("SiteDeveloperSupportText");

            base.OnActionExecuting(filterContext);
        }
    }
}

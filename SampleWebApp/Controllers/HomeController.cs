using SampleWebApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleWebApp.Controllers
{
    public class HomeController : Controller
    {
        private const string LOCAL_FILES = @"C:\tmp\vol";

        public ActionResult Index()
        {
            var files =  new string[0] as IEnumerable<string>;
            if (Directory.Exists(LOCAL_FILES))
            {
                files = Directory.EnumerateFiles(LOCAL_FILES);
            }

            ViewBag.Files = files;

            return View();
        }

        [RequireHttps]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            ViewBag.Books = SomeAPI.GetList();

            return View();
        }
    }
}
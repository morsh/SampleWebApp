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

            if (files == null || files.Count() == 0)
            {
                Logger.Log("Index - No files found");
            }
            else
            {
                Logger.Log("Index - " + files.Count() + " files found");
            }

            ViewBag.Files = files;

            return View();
        }

        [RequireHttps]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            Logger.Log("About Landing");
            
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            var books = SomeAPI.GetList();

            if (books == null || books.Count() == 0)
            {
                Logger.Log("Contact - No books found");
            }
            else
            {
                Logger.Log("Contact - " + books.Count() + " books found");
            }

            ViewBag.Books = books;
            return View();
        }
    }
}
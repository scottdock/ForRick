using RickExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RickExample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var vm = new FilesViewModel();
            var files = System.IO.Directory.GetFiles(@"C:\code\me\RickExample\RickExample\fonts");
            vm.FileNames = files;
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
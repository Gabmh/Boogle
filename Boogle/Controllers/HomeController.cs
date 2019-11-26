using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Boogle.Models;

namespace Boogle.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Nom"] = "Hekmil";
            return View();
        }

        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult Search()
        {
            ViewData["Nom"] = "Hekmil";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

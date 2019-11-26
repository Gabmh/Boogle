using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Boogle.Models;

namespace Boogle.Controllers
{
    public class ProfileController : Controller
    {
        public ActionResult Show()
        {
            ViewData["Nom"] = "Hekmil";
            ViewData["Mail"] = "coucou@gmail.com";
            ViewData["Birth"] = "15/10/95";

            return View();
        }

        public ActionResult Edit()
        {
            ViewData["Nom"] = "Hekmil";


            if (Request.Method == "POST")
            {
                string nPseudo = Request.Form["pseudo"];
                string nMail = Request.Form["mail"];
                string birthDate = Request.Form["dob"];

                ViewData["Nom"] = nPseudo;
                ViewData["Mail"] = nMail;
                ViewData["Birth"] = birthDate;

                return View("Show");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public ActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Boogle.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Boogle.Controllers
{
    public class ProfileController : Controller
    {
        private readonly BoogledbContext _context;

        public ProfileController(BoogledbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Show(int? id)
        {
            id = HttpContext.Session.GetInt32("id");

            var userModel = _context.Usuario.FirstOrDefaultAsync(m => m.Usuario_Id == id);


            List<UserModel> list = await _context.Usuario.ToListAsync();
            int i = 0;
            foreach (UserModel u in list)
            {
                int n = 0;
                if (u.Usuario_Id == 4)
                {
                    i = n;
                }
                n++;
            }

            return View(list[i]);
            
        }

        public IActionResult Edit()
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
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

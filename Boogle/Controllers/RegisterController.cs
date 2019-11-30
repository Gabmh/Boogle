using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boogle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Boogle.Controllers
{
    public class RegisterController : Controller
    {
        private readonly ApplicationUserModel _auc;

        public RegisterController(ApplicationUserModel auc)
        {
            _auc = auc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserModel user)
        {
            user.Usuario_Id = 1;
            user.rol = 1;
            user.Fecha_alta = "10/10/1000";
            _auc.Add(user);
            _auc.SaveChanges();
            ViewBag.message = "User created: " + user.Apodo;

            return View();
        }
    }
}

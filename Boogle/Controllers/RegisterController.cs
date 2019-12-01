using System;
using Boogle.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(UserModel user)
        {
            DateTime today = DateTime.Today;

            user.rol = 0;
            user.Fecha_alta = today.ToString().Split(" ")[0];
            _auc.Add(user);
            ViewBag.message = "User created: " + user.Apodo;

            return View();
        }
    }
}

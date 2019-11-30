using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boogle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;


namespace Boogle.Controllers
{
    public class RegisterController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }
       

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boogle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Boogle.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        // GET: /<controller>/
        public ActionResult Index()
        {
            ViewData["title"] = "Boogle";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Ingresar([Bind("Usuario", "Password")] LoginModel login)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from usuario where apodo='"+login.Usuario+"' and password='"+login.Password+"'";
            dr = com.ExecuteReader();


            if (dr.Read() && ModelState.IsValid)
            {
                Debug.WriteLine(dr.Read());
                con.Close();
                return RedirectToAction("Index", "Home");
                
            } else 
            {
                con.Close();
                return RedirectToAction("Index");
            }
        }


        void connectionString()
        {
            con.ConnectionString = "data source=(localdb)\\MSSQLLocalDB; database=Boogledb; integrated security= SSPI;";
        }

        public ActionResult Registrar()
        {
            return View();
        }
    }
}

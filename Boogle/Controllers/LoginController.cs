using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Boogle.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace Boogle.Controllers
{
    public class LoginController : Controller
    {
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;

        public IActionResult Index()
        {
            ViewData["title"] = "Boogle";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Ingresar([Bind("Usuario_id","Apodo", "Password")] UserModel login)
        {
            connectionString();
            con.Open();
            com.Connection = con;
            com.CommandText = "select * from usuario where apodo='"+login.Apodo+"' and password='"+login.Password+"'";
            dr = com.ExecuteReader();

            if (dr.Read())
            {
                HttpContext.Session.SetString("user", login.Apodo);
                con.Close();
                con.Open();
                com.CommandText = "select usuario_id from usuario where apodo='" + login.Apodo +"'";
                dr = com.ExecuteReader();
                dr.Read();
                int id = System.Convert.ToInt32(dr[0].ToString());

                HttpContext.Session.SetInt32("id", id);
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

        [Route("logout")]
        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index");
        }
    }
}

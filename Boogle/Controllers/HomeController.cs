using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Boogle.Models;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Boogle.Controllers
{
    public class HomeController : Controller
    {

        private readonly BoogledbContext _context;

        public HomeController(BoogledbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["Nom"] = "Hekmil";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Books()
        {
            return View();
        }

       public IActionResult Search()
        {
            ViewData["Nom"] = "Hekmil";
            return View();
        }

        public IActionResult SearchButton(string searchString)
        {
            var books = from m in _context.Libro
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Titulo.Contains(searchString));
            }
            return RedirectToAction("Index", "Book", new { name =  searchString} );

            //return View("Index","", await books.ToListAsync());
        }

            public async Task<IActionResult> Download(string filename)
        {
            filename = "Semiosis";
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot", "book/pdf/" + filename + ".pdf");

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, GetContentType(path), Path.GetFileName(path));
        }

        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

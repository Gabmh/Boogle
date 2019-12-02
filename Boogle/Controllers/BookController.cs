using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Boogle.Models;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Boogle.Controllers
{
    public class BookController : Controller
    {
        private readonly BoogledbContext _context;

        public BookController(BoogledbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index(string name)
        {
            if (name == "semiosis")
            {
                var boogledbContext = _context.Libro.Include(b => b.Id_AutorNavigation).Include(b => b.Id_EditorNavigation);
                return View(await boogledbContext.ToListAsync());
            }

            return View();
           
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookModel = await _context.Libro
                .Include(b => b.Id_AutorNavigation)
                .Include(b => b.Id_EditorNavigation)
                .FirstOrDefaultAsync(m => m.Libro_Id == id);
            if (bookModel == null)
            {
                return NotFound();
            }

            return View(bookModel);
        }


        public async Task<IActionResult> Download(string filename)
        {
            filename = "Semiosis";
            var path = Path.Combine(Directory.GetCurrentDirectory(),
                           "wwwroot", "book/pdf/"+filename+".pdf");

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



        private bool BookModelExists(int id)
        {
            return _context.Libro.Any(e => e.Libro_Id == id);
        }
    }
}

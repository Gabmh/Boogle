using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Boogle.Models;

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
        public async Task<IActionResult> Index()
        {
            var boogledbContext = _context.Libro.Include(b => b.Id_AutorNavigation).Include(b => b.Id_EditorNavigation);
            return View(await boogledbContext.ToListAsync());
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

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["IdAutor"] = new SelectList(_context.Autor, "IdAutor", "IdAutor");
            ViewData["IdEditor"] = new SelectList(_context.Editor, "IdEditor", "IdEditor");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LibroId,Titulo,Idioma,CantPag,Generos,Eliminado,IdAutor,IdEditor")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutor"] = new SelectList(_context.Autor, "IdAutor", "IdAutor", bookModel.Id_Autor);
            ViewData["IdEditor"] = new SelectList(_context.Editor, "IdEditor", "IdEditor", bookModel.Id_Editor);
            return View(bookModel);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookModel = await _context.Libro.FindAsync(id);
            if (bookModel == null)
            {
                return NotFound();
            }
            ViewData["IdAutor"] = new SelectList(_context.Autor, "IdAutor", "IdAutor", bookModel.Id_Autor);
            ViewData["IdEditor"] = new SelectList(_context.Editor, "IdEditor", "IdEditor", bookModel.Id_Editor);
            return View(bookModel);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LibroId,Titulo,Idioma,CantPag,Generos,Eliminado,IdAutor,IdEditor")] BookModel bookModel)
        {
            if (id != bookModel.Libro_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookModelExists(bookModel.Libro_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdAutor"] = new SelectList(_context.Autor, "IdAutor", "IdAutor", bookModel.Id_Autor);
            ViewData["IdEditor"] = new SelectList(_context.Editor, "IdEditor", "IdEditor", bookModel.Id_Editor);
            return View(bookModel);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
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

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookModel = await _context.Libro.FindAsync(id);
            _context.Libro.Remove(bookModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookModelExists(int id)
        {
            return _context.Libro.Any(e => e.Libro_Id == id);
        }
    }
}

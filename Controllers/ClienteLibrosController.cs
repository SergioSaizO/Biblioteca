using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Data;
using Biblioteca.Models;

namespace Biblioteca.Controllers
{
    public class ClienteLibrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClienteLibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClienteLibros
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ClienteLibro.Include(c => c.Libro);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClienteLibros/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteLibro = await _context.ClienteLibro
                .Include(c => c.Libro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteLibro == null)
            {
                return NotFound();
            }

            return View(clienteLibro);
        }

        // GET: ClienteLibros/Create
        public IActionResult Create()
        {
            ViewData["LibroId"] = new SelectList(_context.Libro, "Id", "Id");
            return View();
        }

        // POST: ClienteLibros/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CLienteId,LibroId")] ClienteLibro clienteLibro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clienteLibro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LibroId"] = new SelectList(_context.Libro, "Id", "Id", clienteLibro.LibroId);
            return View(clienteLibro);
        }

        // GET: ClienteLibros/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteLibro = await _context.ClienteLibro.FindAsync(id);
            if (clienteLibro == null)
            {
                return NotFound();
            }
            ViewData["LibroId"] = new SelectList(_context.Libro, "Id", "Id", clienteLibro.LibroId);
            return View(clienteLibro);
        }

        // POST: ClienteLibros/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CLienteId,LibroId")] ClienteLibro clienteLibro)
        {
            if (id != clienteLibro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clienteLibro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteLibroExists(clienteLibro.Id))
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
            ViewData["LibroId"] = new SelectList(_context.Libro, "Id", "Id", clienteLibro.LibroId);
            return View(clienteLibro);
        }

        // GET: ClienteLibros/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clienteLibro = await _context.ClienteLibro
                .Include(c => c.Libro)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clienteLibro == null)
            {
                return NotFound();
            }

            return View(clienteLibro);
        }

        // POST: ClienteLibros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clienteLibro = await _context.ClienteLibro.FindAsync(id);
            _context.ClienteLibro.Remove(clienteLibro);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteLibroExists(int id)
        {
            return _context.ClienteLibro.Any(e => e.Id == id);
        }
    }
}

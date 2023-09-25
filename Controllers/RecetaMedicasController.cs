using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bloodyvalentinee;
using bloodyvalentinee.Models.Data;
using Microsoft.AspNetCore.Authorization;

namespace bloodyvalentinee.Controllers
{
    [Authorize(Roles = "2")]

    public class RecetaMedicasController : Controller
    {
        private readonly AplicacionDBContext _context;

        public RecetaMedicasController(AplicacionDBContext context)
        {
            _context = context;
        }

        // GET: RecetaMedicas
        public async Task<IActionResult> Index()
        {
            var aplicacionDBContext = _context.RecetaMedica.Include(r => r.Usuario);
            return View(await aplicacionDBContext.ToListAsync());
        }

        // GET: RecetaMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RecetaMedica == null)
            {
                return NotFound();
            }

            var recetaMedica = await _context.RecetaMedica
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.IdRecetaMedica == id);
            if (recetaMedica == null)
            {
                return NotFound();
            }

            return View(recetaMedica);
        }

        // GET: RecetaMedicas/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario");
            return View();
        }

        // POST: RecetaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdRecetaMedica,IdUsuario,Receta")] RecetaMedica recetaMedica)
        {
           
                _context.Add(recetaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", recetaMedica.IdUsuario);
            return View(recetaMedica);
        }

        // GET: RecetaMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RecetaMedica == null)
            {
                return NotFound();
            }

            var recetaMedica = await _context.RecetaMedica.FindAsync(id);
            if (recetaMedica == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", recetaMedica.IdUsuario);
            return View(recetaMedica);
        }

        // POST: RecetaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdRecetaMedica,IdUsuario,Receta")] RecetaMedica recetaMedica)
        {
            if (id != recetaMedica.IdRecetaMedica)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(recetaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecetaMedicaExists(recetaMedica.IdRecetaMedica))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", recetaMedica.IdUsuario);
            return View(recetaMedica);
        }

        // GET: RecetaMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RecetaMedica == null)
            {
                return NotFound();
            }

            var recetaMedica = await _context.RecetaMedica
                .Include(r => r.Usuario)
                .FirstOrDefaultAsync(m => m.IdRecetaMedica == id);
            if (recetaMedica == null)
            {
                return NotFound();
            }

            return View(recetaMedica);
        }

        // POST: RecetaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RecetaMedica == null)
            {
                return Problem("Entity set 'AplicacionDBContext.RecetaMedica'  is null.");
            }
            var recetaMedica = await _context.RecetaMedica.FindAsync(id);
            if (recetaMedica != null)
            {
                _context.RecetaMedica.Remove(recetaMedica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecetaMedicaExists(int id)
        {
          return (_context.RecetaMedica?.Any(e => e.IdRecetaMedica == id)).GetValueOrDefault();
        }
    }
}

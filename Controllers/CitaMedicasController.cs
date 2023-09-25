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

    public class CitaMedicasController : Controller
    {
        private readonly AplicacionDBContext _context;

        public CitaMedicasController(AplicacionDBContext context)
        {
            _context = context;
        }

        // GET: CitaMedicas
        public async Task<IActionResult> Index()
        {
            var aplicacionDBContext = _context.CitaMedica.Include(c => c.Medico).Include(c => c.Usuario);
            return View(await aplicacionDBContext.ToListAsync());
        }

        // GET: CitaMedicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CitaMedica == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica
                .Include(c => c.Medico)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCitaMedica == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // GET: CitaMedicas/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "IdMedico");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "NombreCompleto");
            return View();
        }

        // POST: CitaMedicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCitaMedica,IdMedico,IdUsuario,Consultorio,FechaCita,Motivo,Estado")] CitaMedica citaMedica)
        {
            
                
                _context.Add(citaMedica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
           
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "IdMedico", citaMedica.IdMedico);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "NombreCompleto", citaMedica.IdUsuario);
            return View(citaMedica);
        }

        // GET: CitaMedicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CitaMedica == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica.FindAsync(id);
            if (citaMedica == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "IdMedico", citaMedica.IdMedico);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "NombreCompleto", citaMedica.IdUsuario);
            return View(citaMedica);
        }

        // POST: CitaMedicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCitaMedica,IdMedico,IdUsuario,Consultorio,FechaCita,Motivo,Estado")] CitaMedica citaMedica)
        {
            if (id != citaMedica.IdCitaMedica)
            {
                return NotFound();
            }

            
                try
                {
                    _context.Update(citaMedica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CitaMedicaExists(citaMedica.IdCitaMedica))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["IdMedico"] = new SelectList(_context.Medico, "IdMedico", "IdMedico", citaMedica.IdMedico);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "NombreCompleto", citaMedica.IdUsuario);
            return View(citaMedica);
        }

        // GET: CitaMedicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CitaMedica == null)
            {
                return NotFound();
            }

            var citaMedica = await _context.CitaMedica
                .Include(c => c.Medico)
                .Include(c => c.Usuario)
                .FirstOrDefaultAsync(m => m.IdCitaMedica == id);
            if (citaMedica == null)
            {
                return NotFound();
            }

            return View(citaMedica);
        }

        // POST: CitaMedicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CitaMedica == null)
            {
                return Problem("Entity set 'AplicacionDBContext.CitaMedica'  is null.");
            }
            var citaMedica = await _context.CitaMedica.FindAsync(id);
            if (citaMedica != null)
            {
                _context.CitaMedica.Remove(citaMedica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CitaMedicaExists(int id)
        {
          return (_context.CitaMedica?.Any(e => e.IdCitaMedica == id)).GetValueOrDefault();
        }
    }
}

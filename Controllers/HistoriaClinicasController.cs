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

    public class HistoriaClinicasController : Controller
    {
        private readonly AplicacionDBContext _context;

        public HistoriaClinicasController(AplicacionDBContext context)
        {
            _context = context;
        }

        // GET: HistoriaClinicas
        public async Task<IActionResult> Index()
        {
            var aplicacionDBContext = _context.HistoriaClinica.Include(h => h.EnfermedadHereditaria).Include(h => h.InsGeneral).Include(h => h.Usuario);
            return View(await aplicacionDBContext.ToListAsync());
        }

        // GET: HistoriaClinicas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.HistoriaClinica == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriaClinica
                .Include(h => h.EnfermedadHereditaria)
                .Include(h => h.InsGeneral)
                .Include(h => h.Usuario)
                .FirstOrDefaultAsync(m => m.IdHcu == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Create
        public IActionResult Create()
        {
            ViewData["IdEh"] = new SelectList(_context.EnfermedadHereditaria, "IdEh", "IdEh");
            ViewData["IdIgeneral"] = new SelectList(_context.InsGeneral, "IdIgeneral", "IdIgeneral");
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario");
            return View();
        }

        // POST: HistoriaClinicas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdHcu,IdUsuario,IdMedico,IdIgeneral,IdEh")] HistoriaClinica historiaClinica)
        {
            
                _context.Add(historiaClinica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["IdEh"] = new SelectList(_context.EnfermedadHereditaria, "IdEh", "IdEh", historiaClinica.IdEh);
            ViewData["IdIgeneral"] = new SelectList(_context.InsGeneral, "IdIgeneral", "IdIgeneral", historiaClinica.IdIgeneral);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", historiaClinica.IdUsuario);
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.HistoriaClinica == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriaClinica.FindAsync(id);
            if (historiaClinica == null)
            {
                return NotFound();
            }
            ViewData["IdEh"] = new SelectList(_context.EnfermedadHereditaria, "IdEh", "IdEh", historiaClinica.IdEh);
            ViewData["IdIgeneral"] = new SelectList(_context.InsGeneral, "IdIgeneral", "IdIgeneral", historiaClinica.IdIgeneral);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", historiaClinica.IdUsuario);
            return View(historiaClinica);
        }

        // POST: HistoriaClinicas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdHcu,IdUsuario,IdMedico,IdIgeneral,IdEh")] HistoriaClinica historiaClinica)
        {
            if (id != historiaClinica.IdHcu)
            {
                return NotFound();
            }

           
                try
                {
                    _context.Update(historiaClinica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HistoriaClinicaExists(historiaClinica.IdHcu))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            
            ViewData["IdEh"] = new SelectList(_context.EnfermedadHereditaria, "IdEh", "IdEh", historiaClinica.IdEh);
            ViewData["IdIgeneral"] = new SelectList(_context.InsGeneral, "IdIgeneral", "IdIgeneral", historiaClinica.IdIgeneral);
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", historiaClinica.IdUsuario);
            return View(historiaClinica);
        }

        // GET: HistoriaClinicas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.HistoriaClinica == null)
            {
                return NotFound();
            }

            var historiaClinica = await _context.HistoriaClinica
                .Include(h => h.EnfermedadHereditaria)
                .Include(h => h.InsGeneral)
                .Include(h => h.Usuario)
                .FirstOrDefaultAsync(m => m.IdHcu == id);
            if (historiaClinica == null)
            {
                return NotFound();
            }

            return View(historiaClinica);
        }

        // POST: HistoriaClinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.HistoriaClinica == null)
            {
                return Problem("Entity set 'AplicacionDBContext.HistoriaClinica'  is null.");
            }
            var historiaClinica = await _context.HistoriaClinica.FindAsync(id);
            if (historiaClinica != null)
            {
                _context.HistoriaClinica.Remove(historiaClinica);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HistoriaClinicaExists(int id)
        {
          return (_context.HistoriaClinica?.Any(e => e.IdHcu == id)).GetValueOrDefault();
        }
    }
}

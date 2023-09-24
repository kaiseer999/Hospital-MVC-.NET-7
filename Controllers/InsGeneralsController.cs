using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using bloodyvalentinee;
using bloodyvalentinee.Models.Data;

namespace bloodyvalentinee.Controllers
{
    public class InsGeneralsController : Controller
    {
        private readonly AplicacionDBContext _context;

        public InsGeneralsController(AplicacionDBContext context)
        {
            _context = context;
        }

        // GET: InsGenerals
        public async Task<IActionResult> Index()
        {
            var aplicacionDBContext = _context.InsGeneral.Include(i => i.Usuario);
            return View(await aplicacionDBContext.ToListAsync());
        }

        // GET: InsGenerals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.InsGeneral == null)
            {
                return NotFound();
            }

            var insGeneral = await _context.InsGeneral
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.IdIgeneral == id);
            if (insGeneral == null)
            {
                return NotFound();
            }

            return View(insGeneral);
        }

        // GET: InsGenerals/Create
        public IActionResult Create()
        {
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario");
            return View();
        }

        // POST: InsGenerals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdIgeneral,IdUsuario,ComentarioMc,Altura,PesoReal,PesoIdeal,Imc,Temperatura,FrecuenciaCardiaca,FrecuenciaRespiratoria,ComentarioIg,ComentarioD")] InsGeneral insGeneral)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insGeneral);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", insGeneral.IdUsuario);
            return View(insGeneral);
        }

        // GET: InsGenerals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.InsGeneral == null)
            {
                return NotFound();
            }

            var insGeneral = await _context.InsGeneral.FindAsync(id);
            if (insGeneral == null)
            {
                return NotFound();
            }
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", insGeneral.IdUsuario);
            return View(insGeneral);
        }

        // POST: InsGenerals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdIgeneral,IdUsuario,ComentarioMc,Altura,PesoReal,PesoIdeal,Imc,Temperatura,FrecuenciaCardiaca,FrecuenciaRespiratoria,ComentarioIg,ComentarioD")] InsGeneral insGeneral)
        {
            if (id != insGeneral.IdIgeneral)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(insGeneral);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InsGeneralExists(insGeneral.IdIgeneral))
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
            ViewData["IdUsuario"] = new SelectList(_context.Usuario, "idUsuario", "idUsuario", insGeneral.IdUsuario);
            return View(insGeneral);
        }

        // GET: InsGenerals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.InsGeneral == null)
            {
                return NotFound();
            }

            var insGeneral = await _context.InsGeneral
                .Include(i => i.Usuario)
                .FirstOrDefaultAsync(m => m.IdIgeneral == id);
            if (insGeneral == null)
            {
                return NotFound();
            }

            return View(insGeneral);
        }

        // POST: InsGenerals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.InsGeneral == null)
            {
                return Problem("Entity set 'AplicacionDBContext.InsGeneral'  is null.");
            }
            var insGeneral = await _context.InsGeneral.FindAsync(id);
            if (insGeneral != null)
            {
                _context.InsGeneral.Remove(insGeneral);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InsGeneralExists(int id)
        {
          return (_context.InsGeneral?.Any(e => e.IdIgeneral == id)).GetValueOrDefault();
        }
    }
}

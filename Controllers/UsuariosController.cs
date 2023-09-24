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
    [Authorize ]
    public class UsuariosController : Controller
    {
        private readonly AplicacionDBContext _context;

        public UsuariosController(AplicacionDBContext context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
            var aplicacionDBContext = _context.Usuario.Include(u => u.EPS).Include(u => u.Rol);
            return View(await aplicacionDBContext.ToListAsync());
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.EPS)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            ViewData["EPSIdEps"] = new SelectList(_context.EPS, "IdEps", "IdEps");
            ViewData["RolId"] = new SelectList(_context.Rol, "IdRol", "IdRol");
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("idUsuario,usuarioIdentificacion,Nombre,Apellido,FechaNac,Direccion,Ocupacion,EstadoCivil,Religion,Telefono,EPSIdEps,Contraseña,Email,RolId")] Usuario usuario)
        {
            
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            
            ViewData["EPSIdEps"] = new SelectList(_context.EPS, "IdEps", "IdEps", usuario.EPSIdEps);
            ViewData["RolId"] = new SelectList(_context.Rol, "IdRol", "IdRol", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        [Authorize(Roles = "1")]

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            ViewData["EPSIdEps"] = new SelectList(_context.EPS, "IdEps", "IdEps", usuario.EPSIdEps);
            ViewData["RolId"] = new SelectList(_context.Rol, "IdRol", "IdRol", usuario.RolId);
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> Edit(int id, [Bind("idUsuario,usuarioIdentificacion,Nombre,Apellido,FechaNac,Direccion,Ocupacion,EstadoCivil,Religion,Telefono,EPSIdEps,Contraseña,Email,RolId")] Usuario usuario)
        {
            if (id != usuario.idUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.idUsuario))
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
            ViewData["EPSIdEps"] = new SelectList(_context.EPS, "IdEps", "IdEps", usuario.EPSIdEps);
            ViewData["RolId"] = new SelectList(_context.Rol, "IdRol", "IdRol", usuario.RolId);
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        [Authorize(Roles = "1")]

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .Include(u => u.EPS)
                .Include(u => u.Rol)
                .FirstOrDefaultAsync(m => m.idUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "1")]

        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'AplicacionDBContext.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.idUsuario == id)).GetValueOrDefault();
        }
    }
}

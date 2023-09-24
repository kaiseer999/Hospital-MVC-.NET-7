using Microsoft.AspNetCore.Mvc;
using bloodyvalentinee.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using bloodyvalentinee.Models.Data;


namespace bloodyvalentinee.Controllers
{
    public class AccesoController : Controller
    {
        private readonly AplicacionDBContext _context;

        public AccesoController(AplicacionDBContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Usuario _usuario)
        {

            DA_Usuario _da_usuario = new DA_Usuario(_context);

            var usuario = _da_usuario.ValidarUsuario(_usuario.Email, _usuario.Contraseña);

            if (usuario != null)
            {

                //2.- CONFIGURACION DE LA AUTENTICACION
                #region AUTENTICACTION
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim("Email", usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.RolId.ToString())
                };
                
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
                #endregion


                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

        }

        public async Task<IActionResult> Salir()
        {
            //3.- CONFIGURACION DE LA AUTENTICACION
            #region AUTENTICACTION
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            #endregion

            return RedirectToAction("Index");

        }




    }
}

using bloodyvalentinee.Models.Data;

namespace bloodyvalentinee.Models
{
    public class DA_Usuario
    {

        private readonly AplicacionDBContext _context;

        public DA_Usuario(AplicacionDBContext context)
        {
            _context = context;
        }

        public Usuario ValidarUsuario(string email, string contra)
        {
            return _context.Usuario.FirstOrDefault(u => u.Email == email && u.Contraseña == contra);








        }
    }
}

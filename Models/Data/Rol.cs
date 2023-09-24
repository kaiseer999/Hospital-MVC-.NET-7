using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; } = null!;


    }
}

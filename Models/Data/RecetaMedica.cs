using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class RecetaMedica
    {
        [Key]
        public int IdRecetaMedica { get; set; }
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public string Receta { get; set; }
        //add-migration RecetaMedica
    }
}

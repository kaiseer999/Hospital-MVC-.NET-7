using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class EnfermedadHereditaria
    {
        [Key]
        public int IdEh { get; set; }

        public string NombreEh { get; set; } = null!;
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public HistoriaClinica HistoriaClinica { get; set; }

    }
}

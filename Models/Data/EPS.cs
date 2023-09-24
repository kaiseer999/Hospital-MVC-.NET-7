using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class EPS
    {
        [Key]
        public int IdEps { get; set; }

        public string NombreEps { get; set; } = null!;

      //  public HistoriaClinica HistoriaClinica { get; set; }

    }
}

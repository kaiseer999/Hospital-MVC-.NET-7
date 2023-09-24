using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class HistoriaClinica
    {
        [Key]
        public int IdHcu { get; set; }

        public int IdUsuario { get; set; } 
        public Usuario Usuario { get; set; } 



       

      

        public int IdIgeneral { get; set; } 
        public InsGeneral InsGeneral { get; set; } 

        public int IdEh { get; set; } 
        public EnfermedadHereditaria EnfermedadHereditaria { get; set; } 

       

    }
}

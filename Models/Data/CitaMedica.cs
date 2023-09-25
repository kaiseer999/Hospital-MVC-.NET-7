using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class CitaMedica
    {
        [Key]
        public int IdCitaMedica { get; set; } 
        public int IdMedico { get; set; }
        public Medico Medico { get; set; }  
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set;}
        public string Consultorio { get; set; }
        public DateTime FechaCita { get; set; } 
        public string Motivo { get; set; } 
        public string Estado { get; set; }
        //add-migration Medico_Cita
    }
}

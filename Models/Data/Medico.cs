using System.ComponentModel.DataAnnotations;
using bloodyvalentinee.Models.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace bloodyvalentinee.Models.Data
{
    public class Medico
    {
        [Key]
        public int IdMedico { get; set; }
        public int IdUsuario { get; set; }
        public string Especialidad { get; set; }
        public Usuario Usuario { get; set; }
        public CitaMedica CitaMedica { get; set; }




    }
}

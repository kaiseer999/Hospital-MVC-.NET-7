using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class Usuario 
    {
        [Key]
        public int idUsuario {  get; set; }

        public int usuarioIdentificacion { get; set; }  
        public string Nombre { get; set; } = null!;
        public string Apellido { get; set; } = null!;
        public string NombreCompleto => $"{Nombre} {Apellido} {usuarioIdentificacion}";


        public DateTime FechaNac { get; set; }

        public string Direccion { get; set; } = null!;

        public string Ocupacion { get; set; } = null!;

        public string EstadoCivil { get; set; } = null!;

        public string Religion { get; set; } = null!;

        public int Telefono { get; set; }

        public int EPSIdEps { get; set; }
        

        public string Contraseña { get; set; }=null!;
        public string Email { get; set; }
        public int RolId { get; set; }
        public Rol Rol { get; set; } = null!;

        public HistoriaClinica HistoriaClinica { get; set; }

        public InsGeneral InsGeneral { get; set; }
        public EPS EPS { get; set; }
        public Medico Medico { get; set; }
        public CitaMedica CitaMedica { get; set; }

        public RecetaMedica recetaMedica { get; set; }

    }
}

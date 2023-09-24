using System.ComponentModel.DataAnnotations;

namespace bloodyvalentinee.Models.Data
{
    public class InsGeneral
    {
        [Key]
        public int IdIgeneral { get; set; }
        public int IdUsuario { get; set; } 

        public Usuario Usuario { get; set; }
        public string ComentarioMc { get; set; }

        public float Altura { get; set; }

        public float PesoReal { get; set; }

        public float PesoIdeal { get; set; }

        public float Imc { get; set; }

        public float Temperatura { get; set; }

        public int FrecuenciaCardiaca { get; set; }

        public int FrecuenciaRespiratoria { get; set; }
        public int ComentarioIg { get; set; }
        public string ComentarioD { get; set; } = null!;

        public HistoriaClinica HistoriaClinica { get; set; }



    }
}

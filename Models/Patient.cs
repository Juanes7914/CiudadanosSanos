using System.ComponentModel.DataAnnotations;

namespace CiudadanosSanos.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        public string CedulaCiudadania { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public string Enfermedades { get; set; }

        [Required]
        public string Alergias { get; set; }

        [Required]
        public string Direccion { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string NumeroTelefonico { get; set; }
    }
}

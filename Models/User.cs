using System.ComponentModel.DataAnnotations;

namespace CiudadanosSanos.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string NombreCompleto { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string CorreoElectronico { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }
    }
}

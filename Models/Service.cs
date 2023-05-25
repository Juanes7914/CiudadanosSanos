using System.ComponentModel.DataAnnotations;

namespace CiudadanosSanos.Models
{
    public class Service
    {
        public int Id { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}

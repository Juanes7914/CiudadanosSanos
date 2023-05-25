using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CiudadanosSanos.Models
{
    public class Service
    {
        public int Id { get; set; }

        [DisplayName("Ingrese el nombre del cliente")]
        [Required]
        public string Nombre { get; set; }

        [DisplayName("Ingrese la descripción del servicio")]
        [Required]
        public string Descripcion { get; set; }

        [DisplayName("Ingrese el precio del servicio")]
        [Required]
        public decimal Precio { get; set; }
    }
}

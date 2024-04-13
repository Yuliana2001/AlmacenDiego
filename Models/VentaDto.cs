using AlmacenDiego.Models;
using System.ComponentModel.DataAnnotations;


namespace pruebaAlmacen.Models
{
    public class VentaDto
    {
        public ApplicationUser Cliente { get; set; }

        public int Cantidad { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Total { get; set; }
        public string EstadoPago { get; set; } // Puede ser un código definido por la DIAN
        public string MetodoPago { get; set; } // Puede ser un código definido por la DIAN
    }
}

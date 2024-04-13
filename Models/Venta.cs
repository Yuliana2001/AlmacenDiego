using AlmacenDiego.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace pruebaAlmacen.Models
{
    public class Venta
    {
        [Key]
        public Guid Id { get; set; } // Propiedad de identidad y clave primaria
        public ApplicationUser Cliente { get; set; }

        public int Cantidad { get; set; }

        public List<Product> Products { get; set; } = new List<Product>();
        public decimal Total { get; set; }
        public string EstadoPago { get; set; } // Puede ser un código definido por la DIAN
        public string MetodoPago { get; set; } // Puede ser un código definido por la DIAN
        public DateTime CreatedAt { get; set; }


    }
}

using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;
using pruebaAlmacen.Models;
using System.Data;

namespace pruebaAlmacen.Pages
{
    [Authorize(Roles = "admin,seller")]
    public class VentaModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        public List<Product> Products { get; set; } 

        [BindProperty]
        public VentaDto VentaDto { get; set; } = new VentaDto();
        public VentaModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p => p.Id).ToList();

        }
        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, llena todos los campos";
                return;
            }
            Venta venta = new Venta()
            {
            Cliente= VentaDto.Cliente,
            Cantidad=VentaDto.Cantidad,
            Products=VentaDto.Products,
            Total=VentaDto.Total,
            EstadoPago=VentaDto.EstadoPago,
            MetodoPago=VentaDto.MetodoPago
            };
            context.Ventas.Add(venta);
            context.SaveChanges();
            //limpiar todo
            VentaDto.Cliente = new ApplicationUser();
            VentaDto.Cantidad = 0;
            VentaDto.Products.Clear();
            VentaDto.Total = 0;
            VentaDto.EstadoPago = "";
            VentaDto.MetodoPago = "";
            ModelState.Clear();
            successMessage = "Producto creado con exito";
            Response.Redirect("/Products");

        }
    }
}

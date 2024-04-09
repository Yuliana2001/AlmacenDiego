using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages
{
    [Authorize(Roles = "admin")]
    public class ProductsModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductsModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products = context.Products.OrderByDescending(p => p.Id).ToList();

        }
    }
}

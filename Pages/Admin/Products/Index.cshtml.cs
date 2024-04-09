using AlmacenDiego.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages.Admin.Products
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<Product> Products { get; set; } = new List<Product>();

        public IndexModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            Products=context.Products.OrderByDescending(p=>p.Id).ToList();
        }
    }
}

using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages
{
    [Authorize(Roles = "admin")]
    public class ProductsModel : PageModel
    {
        private readonly ApplicationDbContext context;

        public PaginatedList<Product> Products { get; set; }

        public ProductsModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task OnGetAsync(int? pageNumber)
        {
            const int pageSize = 5;
            var productsQuery = context.Products.AsNoTracking().OrderByDescending(p => p.Id);
            Products = await PaginatedList<Product>.CreateAsync(productsQuery, pageNumber ?? 1, pageSize);
        }
    }
}

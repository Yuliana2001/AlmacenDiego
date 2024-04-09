using AlmacenDiego.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pruebaAlmacen.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        public DeleteModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(int? id)
        {
            if(id == null)
            {
                Response.Redirect("/Products");
                return;
            }
            var product = context.Products.Find(id);
            if(product == null) {
                Response.Redirect("/Products");
                return;
            }
            string imageFullPath = environment.WebRootPath + "/Products/" + product.ImageFileName;
            System.IO.File.Delete(imageFullPath);
            context.Products.Remove(product);
            context.SaveChanges();
            Response.Redirect("/Products");
        }
    }
}

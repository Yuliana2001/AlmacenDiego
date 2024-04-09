using AlmacenDiego.Services;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages
{
    public class EditModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        [BindProperty]
        public ProductDto ProductDto { get; set; }=new ProductDto();
        public Product Product { get; set; }= new Product();

        public string errorMessage = "";
        public string successMessage = "";
        public EditModel(IWebHostEnvironment environment, ApplicationDbContext context) 
        {
            this.environment = environment;
            this.context = context;
        }
        
        public void OnGet(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin");
            }
            var product = context.Products.Find(id);
            if (product == null)
            {
                Response.Redirect("/Admin");
                return;
            }
            ProductDto.Name=product.Name;
            ProductDto.Brand = product.Brand;
            ProductDto.Category= product.Category;
            ProductDto.Price= product.Price;
            ProductDto.Description=product.Description;
            ProductDto.Price=product.Price;
            Product = product;

        }
        public void OnPost(int? id)
        {
            if (id == null)
            {
                Response.Redirect("/Admin");
                return;
            }
            if (!ModelState.IsValid)
            {
                errorMessage = "Por favor, llene todos los campos";
                return;
            }
            var product = context.Products.Find(id); 
            if(product == null)
            {
                Response.Redirect("/Admin");
                return;
            }
            //cargar imagen si hay una nueva
            string newFilename = product.ImageFileName;
            if (ProductDto.ImageFile != null)
            {
                newFilename = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                newFilename += Path.GetExtension(ProductDto.ImageFile.FileName);

                string imageFullPath = environment.WebRootPath + "/Products/" + newFilename;
                using(var stream=System.IO.File.Create(imageFullPath))
                {
                    ProductDto.ImageFile.CopyTo(stream);
                }
                //borrR imagen
                string oldImageFullPath = environment.WebRootPath + "/Products/" + product.ImageFileName;
                System.IO.File.Delete(oldImageFullPath);
            }
            //cargar producto en la base de datos

            product.Name = ProductDto.Name;
            product.Brand= ProductDto.Brand;
            product.Category= ProductDto.Category;
            product.Price= ProductDto.Price;
            product.Description = ProductDto.Description;
            product.ImageFileName= newFilename;

            context.SaveChanges();




            Product = product;
            successMessage = "Producto actualizado correctamente";
            Response.Redirect("/Products");
        }
    }
}

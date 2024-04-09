using AlmacenDiego.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        [BindProperty]
        public ProductDto ProductDto { get; set; }=new ProductDto();
        public CreateModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment=environment;
            this.context=context;
        }
        public void OnGet()
        {
        }
        public string errorMessage = "";
        public string successMessage = "";
        public void OnPost()
        {
            if (ProductDto.ImageFile == null)
            {
                ModelState.AddModelError("ProductDto.ImageFile", "Se require que suba imagen");
            }
            if(!ModelState.IsValid)
            {
                errorMessage = "Por favor, llena todos los campos";
                return;
            }
            //guardar la imagen
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff");
            newFileName += Path.GetExtension(ProductDto.ImageFile!.FileName);
            string imageFullPath= environment.WebRootPath+"/Products/"+newFileName;
            using(var stream=System.IO.File.Create(imageFullPath))
            {
                ProductDto.ImageFile.CopyTo(stream);
            }
            //guardar todo en bd
            Product product = new Product()
            {
                Name = ProductDto.Name,
                Brand = ProductDto.Brand,
                Category = ProductDto.Category,
                Price = ProductDto.Price,
                Description = ProductDto.Description?? "",
                ImageFileName=newFileName,
                CreatedAt=DateTime.Now,

            };
            context.Products.Add(product);
            context.SaveChanges();
            //limpiar todo
            ProductDto.Name="";
            ProductDto.Brand = "";
            ProductDto.Category = "";
            ProductDto.Price=0;
            ProductDto.Description = "";
            ProductDto.ImageFile=null;

            ModelState.Clear();
            successMessage = "Producto creado con exito";
            Response.Redirect("/Products");
            
        }
    }
}

using AlmacenDiego.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace pruebaAlmacen.Pages
{
    public class DeleteUserModel : PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        public DeleteUserModel(IWebHostEnvironment environment, ApplicationDbContext context)
        {
            this.environment = environment;
            this.context = context;
        }
        public void OnGet(string? id)
        {
            if (id == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }
            var usuario = context.ApplicationUsers.Find(id);
            if (usuario == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }

            context.ApplicationUsers.Remove(usuario);
            context.SaveChanges();
            Response.Redirect("/Usuarios");
        }
    }
}

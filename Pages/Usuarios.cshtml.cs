using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace pruebaAlmacen.Pages
{
    [Authorize(Roles = "admin")]
    public class UsuariosModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
        public UsuariosModel(ApplicationDbContext context)
        {
            this.context = context;
        }
        public void OnGet()
        {
            ApplicationUsers = context.ApplicationUsers.OrderByDescending(p => p.Id).ToList();

        }
    }
}

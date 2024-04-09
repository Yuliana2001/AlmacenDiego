using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using pruebaAlmacen.Models;
using System.Collections.Generic;
using System.Linq;

namespace pruebaAlmacen.Pages
{
    [Authorize(Roles = "admin")]
    public class AdminModel : PageModel
    {
        private readonly ApplicationDbContext context;
        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();

        public AdminModel(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void OnGet()
        {
            ApplicationUsers = context.ApplicationUsers.OrderByDescending(p => p.Id).ToList();
        }
    }
}

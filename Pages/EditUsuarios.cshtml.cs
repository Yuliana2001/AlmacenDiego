using AlmacenDiego.Models;
using AlmacenDiego.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using pruebaAlmacen.Models;

namespace pruebaAlmacen.Pages
{
    public class EditUsuariosModel: PageModel
    {
        private readonly IWebHostEnvironment environment;
        private readonly ApplicationDbContext context;
        private readonly UserManager<ApplicationUser> _userManager;

        [BindProperty]
        public ApplicationUserDto ApplicationUserDto { get; set; } = new ApplicationUserDto();
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();

        public string errorMessage = "";
        public string successMessage = "";
        public EditUsuariosModel(IWebHostEnvironment environment, ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            this.environment = environment;
            this.context = context;
        }

        public void OnGet(string? id)
        {
            if (id == null)
            {
                Response.Redirect("/Usuarios");
            }
            var user = context.ApplicationUsers.Find(id);
            if (user == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }
            ApplicationUserDto.Cedula = user.Cedula;
            ApplicationUserDto.FirstName = user.FirstName;
            ApplicationUserDto.LastName = user.LastName;
            ApplicationUserDto.Address = user.Address;
            ApplicationUserDto.PhoneNumber = user.PhoneNumber;
            ApplicationUserDto.Email = user.Email;
            ApplicationUser = user;

        }
        public async Task OnPostAsync(string? id)
        {
            if (id == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                Response.Redirect("/Usuarios");
                return;
            }

            user.Cedula = ApplicationUserDto.Cedula;
            user.FirstName = ApplicationUserDto.FirstName;
            user.LastName = ApplicationUserDto.LastName;
            user.Address = ApplicationUserDto.Address;
            user.PhoneNumber = ApplicationUserDto.PhoneNumber;
            user.Email = ApplicationUserDto.Email;

            // Obtener el rol seleccionado del DTO
            var selectedRole = ApplicationUserDto.RoleId;

            // Añadir usuario al rol seleccionado
            await _userManager.AddToRoleAsync(user, selectedRole);

            await context.SaveChangesAsync();

            ApplicationUser = user;
            successMessage = "Usuario actualizado correctamente";
            Response.Redirect("/Usuarios");
        }

    }
}
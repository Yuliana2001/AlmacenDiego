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
    public class EditUsuariosModel : PageModel
    {
        private readonly IWebHostEnvironment _environment;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        [BindProperty]
        public ApplicationUserDto ApplicationUserDto { get; set; } = new ApplicationUserDto();
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();
        public string errorMessage = "";
        public string successMessage = "";

        public EditUsuariosModel(IWebHostEnvironment environment, ApplicationDbContext context, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _environment = environment;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("/Usuarios");
            }

            var applicationUser = await _context.ApplicationUsers.FindAsync(id);
            if (applicationUser == null)
            {
                return RedirectToPage("/Usuarios");
            }

            ApplicationUserDto.Cedula = applicationUser.Cedula;
            ApplicationUserDto.FirstName = applicationUser.FirstName;
            ApplicationUserDto.LastName = applicationUser.LastName;
            ApplicationUserDto.PhoneNumber = applicationUser.PhoneNumber;
            ApplicationUserDto.Email = applicationUser.Email;
            ApplicationUserDto.Address = applicationUser.Address;

            ApplicationUser = applicationUser;

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var applicationUser = await _userManager.FindByIdAsync(ApplicationUser.Id);
            if (applicationUser == null)
            {
                return NotFound();
            }

            // Obtener el ID del rol asociado al usuario
            var userRole = await _context.UserRoles.FirstOrDefaultAsync(ur => ur.UserId == applicationUser.Id);



            // Obtener el nombre del rol asociado al ID del rol
            var role = await _roleManager.FindByIdAsync(ApplicationUserDto.RoleId);


            var roleName = role.Name;

            // Asignar el rol al usuario
            var roleResult = await _userManager.AddToRoleAsync(applicationUser, roleName);
            if (!roleResult.Succeeded)
            {
                foreach (var error in roleResult.Errors)
                {
                    errorMessage += "Error en agregar error.";
                }
            }
            else
            {
                successMessage = "El rol se agregó correctamente.";
            }

            return RedirectToPage("/EditUsuarios", new { id = ApplicationUser.Id });
        }
    }
}

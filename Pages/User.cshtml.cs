using AlmacenDiego.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Identity.Client;

namespace pruebaAlmacen.Pages
{
    [Authorize]
    public class UserModel : PageModel
    {
        private readonly UserManager<ApplicationUser> userManager;
        public ApplicationUser? appUser;
        public UserModel(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public void OnGet()
        {
            var task = userManager.GetUserAsync(User);
            task.Wait();
            appUser = task.Result;
        }

    }
}

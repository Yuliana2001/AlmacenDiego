using Microsoft.AspNetCore.Identity;

namespace AlmacenDiego.Models
{
    public class ApplicationUser:IdentityUser
    {
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime CreateAt { get; set; }
    }
}

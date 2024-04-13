using System.ComponentModel.DataAnnotations;

namespace pruebaAlmacen.Models
{
    public class ApplicationUserDto
    {
        public string Cedula { get; set; }
        [Required, MaxLength(100)]
        public string FirstName { get; set; } = "";
        [Required, MaxLength(100)]
        public string LastName { get; set; } = "";
        [Required, MaxLength(100)]
        public string Address { get; set; } = "";
        public string PhoneNumber { get; set; } = "";
        [Required, MaxLength(100)]
        public string Email { get; set; } = "";
        public string RoleId { get; set; } // Agregar para relacionar con la tabla de roles

    }
}

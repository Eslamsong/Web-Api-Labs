using System.ComponentModel.DataAnnotations;

namespace Authentication.DTOs.Users.Register
{
    public class RegisterCrednetials //WrtiteDTO
    {
        public string Username { get; set; } = "";
        public string Password { get; set; } = "";

        [EmailAddress]
        [Required]
        public string Email { get; set; } = "";
        
        public string Department { get; set; } = "";
    }
}

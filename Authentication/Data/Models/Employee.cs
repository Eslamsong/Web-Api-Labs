using Microsoft.AspNetCore.Identity;

namespace Authentication.Data.Models
{
    public class Employee: IdentityUser
    {
        public string Department { get; set; } = "";
    }
}

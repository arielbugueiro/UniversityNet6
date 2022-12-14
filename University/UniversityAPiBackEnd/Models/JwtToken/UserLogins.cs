using Microsoft.Build.Framework;

namespace UniversityAPiBackEnd.Models.JwtToken
{
    public class UserLogins
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

    }
}

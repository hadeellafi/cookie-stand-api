using System.ComponentModel.DataAnnotations;

namespace CookieStandApi.Models.DTOs
{
    public class LoginDataDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

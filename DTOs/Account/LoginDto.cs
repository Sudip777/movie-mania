using System.ComponentModel.DataAnnotations;

namespace MovieMania.DTOs.Account
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}

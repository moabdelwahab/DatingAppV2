using System.ComponentModel.DataAnnotations;

namespace LinkDev.DatingApp.Application.BE.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

    }
}
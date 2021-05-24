using System.ComponentModel.DataAnnotations;

namespace LinkDev.DatingApp.Application.BE.DTOs
{
    public class LoginDTO
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }

    }
}
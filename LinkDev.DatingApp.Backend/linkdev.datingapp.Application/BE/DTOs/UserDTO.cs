using System.ComponentModel.DataAnnotations;

namespace LinkDev.DatingApp.Application.BE.DTOs
{
    public class UserDTO
    {
        [Required]
        public string username { get; set; }
        public string Token { get; set; }

    }
}
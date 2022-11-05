using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class UserSignInDto
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class PhoneUpdateDto
    {
        [Required]
        public long PhoneNumber { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;
    }
}

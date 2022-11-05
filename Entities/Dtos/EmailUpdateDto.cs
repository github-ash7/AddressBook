using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class EmailUpdateDto
    {
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;
    }
}

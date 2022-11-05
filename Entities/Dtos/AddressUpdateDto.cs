using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class AddressUpdateDto
    {
        [Required]
        public string Line1 { get; set; } = string.Empty;

        [Required]
        public string Line2 { get; set; } = string.Empty;

        [Required]
        public string City { get; set; } = string.Empty;

        [Required]
        public int ZipCode { get; set; }

        [Required]
        public string StateName { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Country { get; set; } = string.Empty;
    }
}

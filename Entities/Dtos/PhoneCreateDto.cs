using Entities.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class PhoneCreateDto
    {
        [Required]
        public long PhoneNumber { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;
    }
}

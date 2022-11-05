using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class RefSet
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Key { get; set; } = string.Empty;
    }
}

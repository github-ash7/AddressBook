using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class RefTerm
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;
    }
}

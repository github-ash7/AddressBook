using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Asset
    {
        [Key]
        public Guid Id { get; set; }

        public byte[] Content { get; set; }

        public string ContentType { get; set; } = string.Empty;

        //Below lines establishes a relationship between the tables, "Asset" and "User"
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        //Below lines establishes a relationship between the tables, "Asset" and "RefTerm"
        [ForeignKey("RefTermId")]
        public RefTerm RefTerm { get; set; }
        public Guid RefTermId { get; set; }
    }
}

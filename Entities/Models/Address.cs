using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Address
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Line1 { get; set; } = string.Empty;

        public string Line2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public string StateName { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public int ZipCode { get; set; }

        //Below lines establishes a relationship between the tables, "Address" and "User"
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        //Below lines establishes a relationship between the tables, "Address" and "RefTerm"
        [ForeignKey("RefTermId")]
        public RefTerm RefTerm { get; set; }
        public Guid RefTermId { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Phone
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public long PhoneNumber { get; set; }

        //Below lines establishes a relationship between the tables, "Phone" and "User"
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        //Below lines establishes a relationship between the tables, "Phone" and "RefTerm"
        [ForeignKey("RefTermId")]
        public RefTerm RefTerm { get; set; }
        public Guid RefTermId { get; set; }
    }
}

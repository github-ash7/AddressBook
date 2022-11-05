using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Email
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string EmailAddress { get; set; } = string.Empty;


        //Below lines establishes a relationship between the tables, "Email" and "User"
        [ForeignKey("UserId")]
        public User User { get; set; }
        public Guid UserId { get; set; }

        //Below lines establishes a relationship between the tables, "Email" and "RefTerm"
        [ForeignKey("RefTermId")]
        public RefTerm RefTerm { get; set; }
        public Guid RefTermId { get; set; }
    }
}

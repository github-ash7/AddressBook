using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class SetRefTerm
    {
        [Key]
        public Guid Id { get; set; }

        //Below lines establishes a relationship between the tables, "SetRefTerm" and "RefTerm"
        [ForeignKey("RefTermId")]
        public RefTerm RefTerm { get; set; }
        public Guid RefTermId { get; set; }

        //Below lines establishes a relationship between the tables, "SetRefTerm" and "RefSetId"
        [ForeignKey("RefSetId")]
        public RefSet RefSet { get; set; }
        public Guid RefSetId { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public ICollection<Email> Emails { get; set; } = new List<Email>(); //User can have more tha one email
        public ICollection<Address> Addresses { get; set; } = new List<Address>(); //User can have more tha one address
        public ICollection<Phone> Phones { get; set; } = new List<Phone>(); //User can have more tha one phone number
    }
}

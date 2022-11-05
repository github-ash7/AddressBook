using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class UserCreateDto
    {
        [Required]

        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public ICollection<EmailCreateDto> Emails { get; set; } = new List<EmailCreateDto>(); //User can have more tha one email

        [Required]
        public ICollection<AddressCreateDto> Addresses { get; set; } = new List<AddressCreateDto>(); //User can have more tha one address

        [Required]
        public ICollection<PhoneCreateDto> Phones { get; set; } = new List<PhoneCreateDto>(); //User can have more tha one phone number
    }
}

using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public class UserUpdateDto
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
        public ICollection<EmailUpdateDto> Emails { get; set; } = new List<EmailUpdateDto>(); //User can have more tha one email

        [Required]
        public ICollection<AddressUpdateDto> Addresses { get; set; } = new List<AddressUpdateDto>(); //User can have more tha one address

        [Required]
        public ICollection<PhoneUpdateDto> Phones { get; set; } = new List<PhoneUpdateDto>(); //User can have more tha one phone number
    }
}

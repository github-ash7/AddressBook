using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace Entities.Dtos
{
    public class UserResponseDto
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public ICollection<EmailResponseDto> Emails { get; set; } = new List<EmailResponseDto>(); //User can have more tha one email

        public ICollection<AddressResponseDto> Addresses { get; set; } = new List<AddressResponseDto>(); //User can have more tha one address

        public ICollection<PhoneResponseDto> Phones { get; set; } = new List<PhoneResponseDto>(); //User can have more tha one phone number

    }
}

namespace Entities.Dtos
{
    public class AddressResponseDto
    {
        public Guid Id { get; set; }

        public string Line1 { get; set; } = string.Empty;

        public string Line2 { get; set; } = string.Empty;

        public string City { get; set; } = string.Empty;

        public int ZipCode { get; set; }

        public string StateName { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;
    }
}

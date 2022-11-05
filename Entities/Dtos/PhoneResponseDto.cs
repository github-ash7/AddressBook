namespace Entities.Dtos
{
    public class PhoneResponseDto
    {
        public Guid Id { get; set; }

        public long PhoneNumber { get; set; }

        public string Type { get; set; } = string.Empty;
    }
}

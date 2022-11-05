namespace Entities.Dtos
{
    public class EmailResponseDto
    {
        public Guid Id { get; set; }
        public string EmailAddress { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
    }
}

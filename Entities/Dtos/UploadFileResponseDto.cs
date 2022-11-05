namespace Entities.Dtos
{
    public class UploadFileResponseDto
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string FileName { get; set; } = string.Empty;

        public string ContentType { get; set; } = string.Empty;

        public string Extension { get; set; } = string.Empty;
    }
}

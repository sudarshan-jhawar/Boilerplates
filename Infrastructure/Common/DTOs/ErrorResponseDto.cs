namespace Infrastructure.Common.DTOs;

public record ErrorResponseDto(Guid CorrelationId, string Error)
{
    public HttpStatusCode StatusCode { get; set; }
    public List<string> Messages { get; set; } = new();
}

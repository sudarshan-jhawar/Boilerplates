namespace Infrastructure.Common.DTOs;

public record AuditableDto : BaseDto
{
    public Guid CreatedBy { get; set; }
    public Guid ModifiedBy { get; set; }
    public DateTimeOffset CreatedDateTime { get; set; }
    public DateTimeOffset UpdatedDateTime { get; set; }

}

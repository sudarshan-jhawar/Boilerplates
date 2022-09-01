namespace Infrastructure.Core.Events;

public class Event:IEvent
{
    public virtual Guid Id { get; } = Guid.NewGuid();

    public virtual DateTimeOffset Created { get; } = DateTimeOffset.UtcNow;
}

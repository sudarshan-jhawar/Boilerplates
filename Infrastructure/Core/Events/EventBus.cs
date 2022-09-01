using MediatR;

namespace Infrastructure.Core.Events;

internal class EventBus : IEventBus
{
    private readonly IMediator _mediator;

    public EventBus(IMediator mediator)
    {
        _mediator = mediator ?? throw new Exception($"Missing dependency '{nameof(IMediator)}'");
    }
    //public Task Commit(params IEvent[] events)
    //{
    //    throw new NotImplementedException();
    //}

    public async Task PublishLocal(params IEvent[] events)
    {
        foreach (var @event in events)
        {
            await _mediator.Publish(@event);
        }
    }
}

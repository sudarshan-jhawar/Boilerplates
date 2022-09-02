using MediatR;

namespace Infrastructure.Core.Queries;

public class QueryBus : IQueryBus
{
    private readonly IMediator _mediator;

    public QueryBus(IMediator mediator)
    {
        _mediator = mediator ?? throw new Exception($"Missing Dependency '{nameof(IMediator)}'");
    }
    public virtual async Task<TResponse> Send<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(query, cancellationToken);
        return result;
    }
}

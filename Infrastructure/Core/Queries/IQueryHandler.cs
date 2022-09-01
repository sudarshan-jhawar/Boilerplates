using MediatR;

namespace Infrastructure.Core.Commands;

public interface IQueryHandler<in TRequest, TResponse> : IRequestHandler<TRequest, TResponse> where TRequest : IQuery<TResponse> { }

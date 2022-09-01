using MediatR;

namespace Infrastructure.Core.Commands;

public interface IQuery<out TResponse> : IRequest<TResponse> { }

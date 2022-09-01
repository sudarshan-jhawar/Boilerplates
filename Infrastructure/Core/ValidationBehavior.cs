using FluentValidation;
using Infrastructure.Core.Commands;
using MediatR;

namespace Infrastructure.Core;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>, IQueryable<TResponse>
{
    private readonly IValidator _validator;

    public ValidationBehavior(IValidator validator)
    {
        _validator = validator; ;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        var result = _validator?.Validate(new ValidationContext<TRequest>(request));

        if (result is not null && !result.IsValid)
            throw new ValidationException(result.Errors);

        return await next();
    }
}
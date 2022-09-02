using FluentValidation;
using Infrastructure.Core.Commands;
using MediatR;

namespace Infrastructure.Core;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : ICommand<TResponse>, IQueryable<TResponse>
{
    private readonly IEnumerable<IValidator> _validators;

    public ValidationBehavior(IEnumerable<IValidator> validators)
    {
        _validators = validators;
    }
    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        if (_validators.Any())
        {
            ValidationContext<TRequest> validationContext = new(request);
            var validationResult = await Task.WhenAll(_validators.Select(_ => _.ValidateAsync(validationContext, cancellationToken)));
            var failures = validationResult.SelectMany(_ => _.Errors).Where(_ => _ is not null);
            if (failures.Any())
                throw new ValidationException(failures);

        }
        return await next();
    }
}
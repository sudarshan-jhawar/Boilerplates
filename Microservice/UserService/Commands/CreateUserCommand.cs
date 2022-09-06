using FluentValidation;
using Infrastructure.Core.Commands;
using UserService.DTOs;

namespace UserService.Commands;

public class CreateUserCommand
{
    public class Validator : AbstractValidator<CreateUserDto>
    {
        public Validator()
        {
            RuleFor(c => c.FirstName).NotEmpty();
            RuleFor(c => c.LastName).NotEmpty();
            RuleFor(c => c.Email).NotEmpty().EmailAddress();
        }
    }
    public class Handler : ICommandHandler<CreateUserDto, Guid>
    {
        public Handler()
        {
            // dependencirs to be added later
        }
        public async Task<Guid> Handle(CreateUserDto request, CancellationToken cancellationToken)
        {
            // business logic goes here.
            //change this after db logic
            return await Task.FromResult(Guid.NewGuid());
        }
    }
}

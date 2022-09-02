using FluentValidation;
using Infrastructure.Core.Commands;
using MediatR;
using UserService.DTOs;

namespace UserService.Commands
{
    public class UpdateUserCommand
    {
        
        public class Validator : AbstractValidator<UpdateUserDto>
        {
            public Validator()
            {
                RuleFor(c => c.FirstName).NotEmpty();
                RuleFor(c => c.LastName).NotEmpty();
            }
        }
        public class Handler : ICommandHandler<UpdateUserDto>
        {
            public Handler()
            {
                // dependencirs to be added later
            }
            public async Task<Unit> Handle(UpdateUserDto request, CancellationToken cancellationToken)
            {
                //change this after db logic
                return await Unit.Task;
            }
        }
    }
}

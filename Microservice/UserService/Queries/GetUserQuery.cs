using FluentValidation;
using Infrastructure.Core.Queries;
using UserService.DTOs;

namespace UserService.Queries;

public class GetUserQuery
{        
    public class Validator : AbstractValidator<GetUserDto>
    {
        public Validator() { }
    }
    public class Handler : IQueryHandler<GetUserDto, UserDto>
    {
        public Handler()
        {
            // dependencirs to be added later
        }
        public async Task<UserDto> Handle(GetUserDto request, CancellationToken cancellationToken)
        {
            // business logic goes here.
            //change this after db logic
            return await Task.FromResult(new UserDto("Sudarshan", "Jhawar", "sudarshan891@gmail.com"));
        }
    }
}

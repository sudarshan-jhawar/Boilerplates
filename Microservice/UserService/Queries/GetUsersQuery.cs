using FluentValidation;
using Infrastructure.Core.Queries;
using UserService.DTOs;

namespace UserService.Queries
{
    public class GetUsersQuery
    {
        public class Validator : AbstractValidator<GetUsersDto>
        {
            public Validator() { }
        }
        public class Handler : IQueryHandler<GetUsersDto, List<UserDto>>
        {
            public Handler()
            {
                // dependencirs to be added later
            }
            public async Task<List<UserDto>> Handle(GetUsersDto request, CancellationToken cancellationToken)
            {
                // business logic goes here.
                //change this after db logic
                return await Task.FromResult(new List<UserDto>() { new("Sudarshan", "Jhawar", "sudarshan891@gmail.com") });
            }
        }
    }
}

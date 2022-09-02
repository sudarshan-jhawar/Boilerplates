using Infrastructure.Core.Commands;
using Infrastructure.Core.Queries;

namespace UserService.DTOs
{
    public record UserDto(string FirstName, string LastName, string Email);
    public record CreateUserDto(string FirstName, string LastName, string Email) : ICommand<Guid>;
    public record UpdateUserDto(Guid Id, string FirstName, string LastName) : ICommand;
    public record GetUserDto(Guid Id) : IQuery<UserDto>;
    public record GetUsersDto() : IQuery<List<UserDto>>;

}

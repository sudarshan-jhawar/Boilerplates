using Infrastructure.Common.DTOs;
using Infrastructure.Core.Commands;
using Infrastructure.Core.Queries;

namespace UserService.DTOs;

public record UserDto(string FirstName, string LastName, string Email) : AuditableDto;
public record CreateUserDto(string FirstName, string LastName, string Email) : ICommand<Guid>;
public record UpdateUserDto(string FirstName, string LastName) : BaseDto, ICommand;
public record DeleteUserDto : BaseDto, ICommand;
public record GetUsersDto : IQuery<List<UserDto>>;
public record GetUserDto : BaseDto, IQuery<UserDto>;

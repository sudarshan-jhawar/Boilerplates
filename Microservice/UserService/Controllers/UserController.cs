using Infrastructure.Core.Commands;
using Infrastructure.Core.Queries;
using Microsoft.AspNetCore.Mvc;
using UserService.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UserService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IQueryBus _queryBus;
    private readonly ICommandBus _commandBus;

    public UserController(IQueryBus queryBus, ICommandBus commandBus)
    {
        _queryBus = queryBus;
        _commandBus = commandBus;
    }
    // GET: api/<UserController>
    [HttpGet]
    public async Task<ActionResult> GetUsers(CancellationToken cancellationToken) =>
        Ok(await _queryBus.Send(new GetUsersDto(), cancellationToken));

    // GET api/<UserController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUser([FromRoute] Guid Id, CancellationToken cancellationToken) =>
        Ok(await _queryBus.Send(new GetUserDto { Id = Id }, cancellationToken));

    // POST api/<UserController>
    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto createUserDto, CancellationToken cancellationToken)
    {
        await _commandBus.Send(createUserDto, cancellationToken);
        return NoContent();
    }

    // PUT api/<UserController>
    [HttpPut]
    public async Task<ActionResult> UpdateUser([FromBody] UpdateUserDto updateUserDto, CancellationToken cancellationToken)
    {
        await _commandBus.Send(updateUserDto, cancellationToken);
        return NoContent();
    }


    // DELETE api/<UserController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] Guid Id, CancellationToken cancellationToken)
    {
        await _commandBus.Send(new DeleteUserDto { Id = Id }, cancellationToken);
        return NoContent();
    }
}

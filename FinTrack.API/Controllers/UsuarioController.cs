using FinTrack.Application.Commands.User;
using FinTrack.Application.Queries.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsuariosController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
    {
        var usuario = await _mediator.Send(command);
        return Ok(usuario);
    }

    [HttpGet("get/{email}")]
    public async Task<IActionResult> GetByEmail(string email)
    {
        var usuario = await _mediator.Send(new GetUserByEmailQuery(email));
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var usuario = await _mediator.Send(new GetUserByIdQuery(id));
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateUserCommand command)
    {
        var usuario = await _mediator.Send(command);
        return Ok(usuario);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteUserCommand { Id = id });
        if (!result)
            return NotFound();

        return NoContent();
    }
}
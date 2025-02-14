using FinTrack.Application.Commands.DebitosMensal;
using FinTrack.Application.Queries.DebitosMensal;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DebitoMensalController : ControllerBase
{
    private readonly IMediator _mediator;

    public DebitoMensalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateDebitoMensalCommand command)
    {
        var debitoMensal = await _mediator.Send(command);
        return Ok(debitoMensal);
    }

    [HttpGet("get-by-user/{usuarioId}")]
    public async Task<IActionResult> GetDebitoMensalByUserId(Guid usuarioId)
    {
        var debitosMensais = await _mediator.Send(new GetDebitoMensalByUserQuery(usuarioId));

        if (!debitosMensais.Any()) // Verifica se a lista está vazia
            return NotFound();

        return Ok(debitosMensais);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var debitoMensal = await _mediator.Send(new GetDebitoMensalByIdQuery(id));
        if (debitoMensal == null)
            return NotFound();

        return Ok(debitoMensal);
    }

    [HttpGet("get-by-nome/{nome}")]
    public async Task<IActionResult> GetByNome(string nome)
    {
        var debitoMensal = await _mediator.Send(new GetDebitoMensalByNomeQuery(nome));
        if (debitoMensal == null)
            return NotFound();

        return Ok(debitoMensal);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateDebitoMensalCommand command)
    {
        var debitoMensal = await _mediator.Send(command);
        return Ok(debitoMensal);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteDebitoMensalCommand { Id = id });
        if (!result)
            return NotFound();

        return NoContent();
    }
}

using FinTrack.Application.Commands.ControlesMensal;
using FinTrack.Application.Commands.ControlesMensalCredito;
using FinTrack.Application.Commands.ControlesMensalDebito;
using FinTrack.Application.Queries.ControlesMensal;
using FinTrack.Application.Queries.ControlesMensalCredito;
using FinTrack.Application.Queries.ControlesMensalDebito;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ControleMensalController : ControllerBase
{
    private readonly IMediator _mediator;

    public ControleMensalController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateControleMensalCommand command)
    {
        var controleMensal = await _mediator.Send(command);
        return Ok(controleMensal);
    }

    [HttpPost("registrar-credito")]
    public async Task<IActionResult> RegistrarCredito([FromBody] CreateControleMensalCreditoCommand command)
    {
        var credito = await _mediator.Send(command);
        return Ok(credito);
    }

    [HttpPost("registrar-debito")]
    public async Task<IActionResult> RegistrarDebito([FromBody] CreateControleMensalDebitoCommand command)
    {
        var debito = await _mediator.Send(command);
        return Ok(debito);
    }

    [HttpGet("get-by-user/{usuarioId}")]
    public async Task<IActionResult> GetControleMensalByUserId(Guid usuarioId)
    {
        var controleMensal = await _mediator.Send(new GetControleMensalByUsuarioQuery(usuarioId));

        if (!controleMensal.Any()) // Verifica se a lista está vazia
            return NotFound();

        return Ok(controleMensal);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var controleMensal = await _mediator.Send(new GetControleMensalByIdQuery(id));
        if (controleMensal == null)
            return NotFound();

        return Ok(controleMensal);
    }

    [HttpGet("get-credito-by-id/{id}")]
    public async Task<IActionResult> GetCreditoById(Guid id)
    {
        var credito = await _mediator.Send(new GetControleMensalCreditoByIdQuery(id));
        if (credito == null)
            return NotFound();

        return Ok(credito);
    }

    [HttpGet("get-debito-by-id/{id}")]
    public async Task<IActionResult> GetDebitoById(Guid id)
    {
        var debito = await _mediator.Send(new GetControleMensalDebitoByIdQuery(id));
        if (debito == null)
            return NotFound();

        return Ok(debito);
    }

    [HttpGet("getAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _mediator.Send(new GetAllControleMensalQuery());
        return Ok(result);
    }

    [HttpGet("get-creditos-by-controle-mensal/{idControleMensal}")]
    public async Task<IActionResult> GetCreditosByControleMensal(Guid idControleMensal)
    {
        var creditos = await _mediator.Send(new GetControleMensalCreditosByControleMensalIdQuery(idControleMensal));
        if (creditos == null)
            return NotFound();

        return Ok(creditos);
    }

    [HttpGet("get-debitos-by-controle-mensal/{idControleMensal}")]
    public async Task<IActionResult> GetDebitosByControleMensal(Guid idControleMensal)
    {
        var debitos = await _mediator.Send(new GetControleMensalDebitosByControleMensalIdQuery(idControleMensal));
        if (debitos == null)
            return NotFound();

        return Ok(debitos);
    }

    [HttpGet("resumo/{idUsuario}/{mes}/{ano}")]
    public async Task<IActionResult> GetResumo(Guid idUsuario, string mes, string ano)
    {
        var query = new GetControleMensalResumoQuery(idUsuario, mes, ano);
        var result = await _mediator.Send(query);

        if (result == null)
            return NotFound("Nenhum controle encontrado para esse período.");

        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateControleMensalCommand command)
    {
        var controleMensal = await _mediator.Send(command);
        return Ok(controleMensal);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteControleMensalCommand { Id = id });
        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("delete-credito/{id}")]
    public async Task<IActionResult> DeleteCredito(Guid id)
    {
        var result = await _mediator.Send(new DeleteControleMensalCreditoCommand(id));
        if (!result)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("delete-debito/{id}")]
    public async Task<IActionResult> DeleteDebito(Guid id)
    {
        var result = await _mediator.Send(new DeleteControleMensalDebitoCommand(id));
            return NotFound();

        return NoContent();
    }

}

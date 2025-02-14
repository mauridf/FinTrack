using FinTrack.Application.Commands.AplicacoesFinanceiras;
using FinTrack.Application.Commands.HistoricosAplicacoesFinanceiras;
using FinTrack.Application.Queries.AplicacoesFinanceiras;
using FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AplicacaoFinanceiraController : ControllerBase
{
    private readonly IMediator _mediator;

    public AplicacaoFinanceiraController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateAplicacaoFinanceiraCommand command)
    {
        var aplicacaoFinanceira = await _mediator.Send(command);
        return Ok(aplicacaoFinanceira);
    }

    [HttpPost("gerar-historico")]
    public async Task<IActionResult> CreateHistorico([FromBody] CreateHistoricoAplicacaoFinanceiraCommand command)
    {
        var historico = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateHistorico), new { id = historico.Id }, historico);
    }

    [HttpGet("get-by-user/{usuarioId}")]
    public async Task<IActionResult> GetAplicacoFinanceiraByUserId(Guid usuarioId)
    {
        var aplicacoesFinanceiras = await _mediator.Send(new GetAplicacaoFinanceiraByUserQuery(usuarioId));

        if (!aplicacoesFinanceiras.Any()) // Verifica se a lista está vazia
            return NotFound();

        return Ok(aplicacoesFinanceiras);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var aplicacaoFinanceira = await _mediator.Send(new GetAplicacaoFinanceiraByIdQuery(id));
        if (aplicacaoFinanceira == null)
            return NotFound();

        return Ok(aplicacaoFinanceira);
    }

    [HttpGet("get-by-nome/{nome}")]
    public async Task<IActionResult> GetByNome(string nome)
    {
        var aplicacaoFinanceira = await _mediator.Send(new GetAplicacaoFinanceiraByNomeQuery(nome));
        if (aplicacaoFinanceira == null)
            return NotFound();

        return Ok(aplicacaoFinanceira);
    }

    [HttpGet("historico-by-id{id}")]
    public async Task<IActionResult> GetHistoricoById(Guid id)
    {
        var result = await _mediator.Send(new GetHistoricoAplicacaoFinanceiraByIdQuery(id));
        return result != null ? Ok(result) : NotFound();
    }

    [HttpGet("historico-by-aplicacao-financeira/{aplicacaoFinanceiraId}")]
    public async Task<IActionResult> GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceira(Guid aplicacaoFinanceiraId)
    {
        var result = await _mediator.Send(new GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceiraQuery(aplicacaoFinanceiraId));
        return Ok(result);
    }

    [HttpGet("aplicacao/{aplicacaoFinanceiraId}/creditos")]
    public async Task<IActionResult> GetCreditosByAplicacaoFinanceira(Guid aplicacaoFinanceiraId)
    {
        var result = await _mediator.Send(new GetCreditosByAplicacaoFinanceiraQuery(aplicacaoFinanceiraId));
        return Ok(result);
    }

    [HttpGet("aplicacao/{aplicacaoFinanceiraId}/debitos")]
    public async Task<IActionResult> GetDebitosByAplicacaoFinanceira(Guid aplicacaoFinanceiraId)
    {
        var result = await _mediator.Send(new GetDebitosByAplicacaoFinanceiraQuery(aplicacaoFinanceiraId));
        return Ok(result);
    }

    [HttpGet("{idUsuario}/{aplicacaoFinanceiraId}/resumo")]
    public async Task<IActionResult> GetResumoAplicacaoFinanceira(Guid idUsuario, Guid aplicacaoFinanceiraId, [FromQuery] DateTime dataInicio, [FromQuery] DateTime dataFim)
    {
        var query = new GetResumoAplicacaoFinanceiraQuery(idUsuario, aplicacaoFinanceiraId, dataInicio, dataFim);
        var resultado = await _mediator.Send(query);

        if (resultado == null)
            return NotFound("Nenhum dado encontrado para o período informado.");

        return Ok(resultado);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateAplicacaoFinanceiraCommand command)
    {
        var aplicacaoFinanceira = await _mediator.Send(command);
        return Ok(aplicacaoFinanceira);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteAplicacaoFinanceiraCommand { Id = id });
        if (!result)
            return NotFound();

        return NoContent();
    }
}

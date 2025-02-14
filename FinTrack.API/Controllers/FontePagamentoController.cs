using FinTrack.Application.Commands.FontesPagamento;
using FinTrack.Application.Queries.FontesPagamento;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinTrack.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FontePagamentoController : ControllerBase
{
    private readonly IMediator _mediator;

    public FontePagamentoController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateFontePagamentoCommand command)
    {
        var fontePagamento = await _mediator.Send(command);
        return Ok(fontePagamento);
    }

    [HttpGet("get-by-user/{usuarioId}")]
    public async Task<IActionResult> GetFontePagamentoByUserId(Guid usuarioId)
    {
        var fontesPagamento = await _mediator.Send(new GetFontePagamentoByUserQuery(usuarioId));

        if (!fontesPagamento.Any()) // Verifica se a lista está vazia
            return NotFound();

        return Ok(fontesPagamento);
    }

    [HttpGet("get-by-id/{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var fontePagamento = await _mediator.Send(new GetFontePagamentoByIdQuery(id));
        if (fontePagamento == null)
            return NotFound();

        return Ok(fontePagamento);
    }

    [HttpGet("get-by-nome/{nome}")]
    public async Task<IActionResult> GetByNome(string nome)
    {
        var fontePagamento = await _mediator.Send(new GetFontePagamentoByNomeQuery(nome));
        if (fontePagamento == null)
            return NotFound();

        return Ok(fontePagamento);
    }

    [HttpPut("update")]
    public async Task<IActionResult> Update([FromBody] UpdateFontePagamentoCommand command)
    {
        var fontePagamento = await _mediator.Send(command);
        return Ok(fontePagamento);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _mediator.Send(new DeleteFontePagamentoCommand { Id = id });
        if (!result)
            return NotFound();

        return NoContent();
    }
}

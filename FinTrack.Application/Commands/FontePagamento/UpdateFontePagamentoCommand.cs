using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.FontesPagamento;

public class UpdateFontePagamentoCommand : IRequest<FontePagamento>
{
    public Guid Id { get; set; }
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
}

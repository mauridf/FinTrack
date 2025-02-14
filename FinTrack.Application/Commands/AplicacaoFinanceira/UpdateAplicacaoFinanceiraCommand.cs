using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.AplicacoesFinanceiras;

public class UpdateAplicacaoFinanceiraCommand : IRequest<AplicacaoFinanceira>
{
    public Guid Id { get; set; }
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
}

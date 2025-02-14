using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.AplicacoesFinanceiras;

public class CreateAplicacaoFinanceiraCommand : IRequest<AplicacaoFinanceira>
{
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
}

using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.DebitosMensal;

public class UpdateDebitoMensalCommand : IRequest<DebitoMensal>
{
    public Guid Id { get; set; }
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public bool Pago { get; set; } = false;
}

using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.DebitosMensal;

public class CreateDebitoMensalCommand : IRequest<DebitoMensal>
{
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    public bool Pago { get; set; } = false;
}

using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.ControlesMensal;

public class UpdateControleMensalCommand : IRequest<ControleMensal>
{
    public Guid Id { get; set; }
    public string Mes { get; set; }
    public string Ano { get; set; }
    public string? Observacao { get; set; }
    public decimal TotalCreditos { get; set; } = 0;
    public decimal TotalDebitos { get; set; } = 0;
    public decimal Saldo { get; set; } = 0;
}

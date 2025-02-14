using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.ControlesMensal;

public class CreateControleMensalCommand : IRequest<ControleMensal>
{
    public Guid IdUsuario { get; set; }
    public string Mes { get; set; }
    public string Ano { get; set; }
    public string? Observacao { get; set; }
    public decimal TotalCreditos { get; set; } = 0;
    public decimal TotalDebitos { get; set; } = 0;
    public decimal Saldo { get; set; } = 0;
}

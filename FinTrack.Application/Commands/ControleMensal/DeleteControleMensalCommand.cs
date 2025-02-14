using MediatR;

namespace FinTrack.Application.Commands.ControlesMensal;

public class DeleteControleMensalCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

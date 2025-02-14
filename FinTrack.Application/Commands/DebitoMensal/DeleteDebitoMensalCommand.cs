using MediatR;

namespace FinTrack.Application.Commands.DebitosMensal;

public class DeleteDebitoMensalCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

using MediatR;

namespace FinTrack.Application.Commands.ControlesMensalDebito;

public class DeleteControleMensalDebitoCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteControleMensalDebitoCommand(Guid id)
    {
        Id = id;
    }
}

using MediatR;

namespace FinTrack.Application.Commands.ControlesMensalCredito;

public class DeleteControleMensalCreditoCommand : IRequest<bool>
{
    public Guid Id { get; set; }

    public DeleteControleMensalCreditoCommand(Guid id)
    {
        Id = id;
    }
}

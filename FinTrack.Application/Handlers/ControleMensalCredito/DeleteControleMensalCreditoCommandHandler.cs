using FinTrack.Application.Commands.ControlesMensalCredito;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalCredito;

public class DeleteControleMensalCreditoCommandHandler : IRequestHandler<DeleteControleMensalCreditoCommand, bool>
{
    private readonly IControleMensalCreditoRepository _repository;

    public DeleteControleMensalCreditoCommandHandler(IControleMensalCreditoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteControleMensalCreditoCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}

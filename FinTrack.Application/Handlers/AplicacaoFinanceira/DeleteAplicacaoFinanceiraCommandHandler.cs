using FinTrack.Application.Commands.AplicacoesFinanceiras;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.AplicacoesFinanceiras;

public class DeleteAplicacaoFinanceiraCommandHandler : IRequestHandler<DeleteAplicacaoFinanceiraCommand, bool>
{
    private readonly IAplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;

    public DeleteAplicacaoFinanceiraCommandHandler(IAplicacaoFinanceiraRepository aplicacaoFinanceiraRepository)
    {
        _aplicacaoFinanceiraRepository = aplicacaoFinanceiraRepository;
    }

    public async Task<bool> Handle(DeleteAplicacaoFinanceiraCommand request, CancellationToken cancellationToken)
    {
        return await _aplicacaoFinanceiraRepository.DeleteAsync(request.Id);
    }
}

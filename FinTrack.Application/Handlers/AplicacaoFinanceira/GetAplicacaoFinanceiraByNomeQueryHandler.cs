using FinTrack.Application.Queries.AplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.AplicacoesFinanceiras;

public class GetAplicacaoFinanceiraByNomeQueryHandler : IRequestHandler<GetAplicacaoFinanceiraByNomeQuery, AplicacaoFinanceira>
{
    private readonly IAplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;

    public GetAplicacaoFinanceiraByNomeQueryHandler(IAplicacaoFinanceiraRepository aplicacaoFinanceiraRepository)
    {
        _aplicacaoFinanceiraRepository = aplicacaoFinanceiraRepository;
    }

    public async Task<AplicacaoFinanceira> Handle(GetAplicacaoFinanceiraByNomeQuery request, CancellationToken cancellationToken)
    {
        return await _aplicacaoFinanceiraRepository.GetByNomeAsync(request.nome);
    }
}

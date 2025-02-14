using FinTrack.Application.Queries.AplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.AplicacoesFinanceiras;

public class GetAplicacaoFinanceiraByIdQueryHandler : IRequestHandler<GetAplicacaoFinanceiraByIdQuery, AplicacaoFinanceira>
{
    private readonly IAplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;

    public GetAplicacaoFinanceiraByIdQueryHandler(IAplicacaoFinanceiraRepository aplicacaoFinanceiraRepository)
    {
        _aplicacaoFinanceiraRepository = aplicacaoFinanceiraRepository;
    }

    public async Task<AplicacaoFinanceira> Handle(GetAplicacaoFinanceiraByIdQuery request, CancellationToken cancellationToken)
    {
        return await _aplicacaoFinanceiraRepository.GetByIdAsync(request.Id);
    }
}

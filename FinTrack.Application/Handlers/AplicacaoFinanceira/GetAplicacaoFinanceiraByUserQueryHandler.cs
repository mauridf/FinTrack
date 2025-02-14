using FinTrack.Application.Queries.AplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.AplicacoesFinanceiras;

public class GetAplicacaoFinanceiraByUserQueryHandler : IRequestHandler<GetAplicacaoFinanceiraByUserQuery, IEnumerable<AplicacaoFinanceira>>
{
    private readonly IAplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;

    public GetAplicacaoFinanceiraByUserQueryHandler(IAplicacaoFinanceiraRepository aplicacaoFinanceiraRepository)
    {
        _aplicacaoFinanceiraRepository = aplicacaoFinanceiraRepository;
    }

    public async Task<IEnumerable<AplicacaoFinanceira>> Handle(GetAplicacaoFinanceiraByUserQuery request, CancellationToken cancellationToken)
    {
        return await _aplicacaoFinanceiraRepository.GetByIdUserAsync(request.IdUser);
    }
}
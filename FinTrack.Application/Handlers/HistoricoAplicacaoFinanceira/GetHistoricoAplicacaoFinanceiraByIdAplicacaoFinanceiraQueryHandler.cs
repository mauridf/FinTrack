using FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.HistoricosAplicacoesFinanceiras;

public class GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceiraQueryHandler
    : IRequestHandler<GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceiraQuery, IEnumerable<HistoricoAplicacaoFinanceira>>
{
    private readonly IHistoricoAplicacaoFinanceiraRepository _historicoRepository;

    public GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceiraQueryHandler(IHistoricoAplicacaoFinanceiraRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task<IEnumerable<HistoricoAplicacaoFinanceira>> Handle(GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceiraQuery request, CancellationToken cancellationToken)
    {
        return await _historicoRepository.GetByIdAplicacaoFinanceiraAsync(request.AplicacaoFinanceiraId);
    }
}

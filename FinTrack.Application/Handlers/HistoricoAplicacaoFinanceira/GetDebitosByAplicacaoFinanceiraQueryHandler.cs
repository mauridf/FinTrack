using FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.HistoricosAplicacoesFinanceiras;

public class GetDebitosByAplicacaoFinanceiraQueryHandler
    : IRequestHandler<GetDebitosByAplicacaoFinanceiraQuery, IEnumerable<HistoricoAplicacaoFinanceira>>
{
    private readonly IHistoricoAplicacaoFinanceiraRepository _historicoRepository;

    public GetDebitosByAplicacaoFinanceiraQueryHandler(IHistoricoAplicacaoFinanceiraRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task<IEnumerable<HistoricoAplicacaoFinanceira>> Handle(GetDebitosByAplicacaoFinanceiraQuery request, CancellationToken cancellationToken)
    {
        return await _historicoRepository.GetDebitosByAplicacaoFinanceiraAsync(request.AplicacaoFinanceiraId);
    }
}

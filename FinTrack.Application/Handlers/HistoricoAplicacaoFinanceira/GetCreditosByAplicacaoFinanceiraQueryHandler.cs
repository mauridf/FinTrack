using FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.HistoricosAplicacoesFinanceiras;

public class GetCreditosByAplicacaoFinanceiraQueryHandler
    : IRequestHandler<GetCreditosByAplicacaoFinanceiraQuery, IEnumerable<HistoricoAplicacaoFinanceira>>
{
    private readonly IHistoricoAplicacaoFinanceiraRepository _historicoRepository;

    public GetCreditosByAplicacaoFinanceiraQueryHandler(IHistoricoAplicacaoFinanceiraRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task<IEnumerable<HistoricoAplicacaoFinanceira>> Handle(GetCreditosByAplicacaoFinanceiraQuery request, CancellationToken cancellationToken)
    {
        return await _historicoRepository.GetCreditosByAplicacaoFinanceiraAsync(request.AplicacaoFinanceiraId);
    }
}

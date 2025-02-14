using FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.HistoricosAplicacoesFinanceiras;

public class GetHistoricoAplicacaoFinanceiraByIdQueryHandler
    : IRequestHandler<GetHistoricoAplicacaoFinanceiraByIdQuery, HistoricoAplicacaoFinanceira>
{
    private readonly IHistoricoAplicacaoFinanceiraRepository _historicoRepository;

    public GetHistoricoAplicacaoFinanceiraByIdQueryHandler(IHistoricoAplicacaoFinanceiraRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task<HistoricoAplicacaoFinanceira> Handle(GetHistoricoAplicacaoFinanceiraByIdQuery request, CancellationToken cancellationToken)
    {
        return await _historicoRepository.GetByIdAsync(request.Id);
    }
}
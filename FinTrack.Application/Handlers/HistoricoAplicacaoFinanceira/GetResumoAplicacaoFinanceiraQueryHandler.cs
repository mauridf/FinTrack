using FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;
using FinTrack.Domain.DTOs;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.HistoricosAplicacoesFinanceiras;

public class GetResumoAplicacaoFinanceiraHandler : IRequestHandler<GetResumoAplicacaoFinanceiraQuery, ResumoAplicacaoFinanceiraDto>
{
    private readonly IHistoricoAplicacaoFinanceiraRepository _repository;

    public GetResumoAplicacaoFinanceiraHandler(IHistoricoAplicacaoFinanceiraRepository repository)
    {
        _repository = repository;
    }

    public async Task<ResumoAplicacaoFinanceiraDto> Handle(GetResumoAplicacaoFinanceiraQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetResumoByAplicacaoEPeriodoAsync(request.IdUsuario, request.AplicacaoFinanceiraId, request.DataInicio, request.DataFim);
    }
}

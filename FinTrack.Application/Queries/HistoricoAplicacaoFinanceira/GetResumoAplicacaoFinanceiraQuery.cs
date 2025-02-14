using FinTrack.Domain.DTOs;
using MediatR;

namespace FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;

public class GetResumoAplicacaoFinanceiraQuery : IRequest<ResumoAplicacaoFinanceiraDto>
{
    public Guid IdUsuario { get; set; }
    public Guid AplicacaoFinanceiraId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }

    public GetResumoAplicacaoFinanceiraQuery(Guid idUsuario, Guid aplicacaoFinanceiraId, DateTime dataInicio, DateTime dataFim)
    {
        IdUsuario = idUsuario;
        AplicacaoFinanceiraId = aplicacaoFinanceiraId;
        DataInicio = dataInicio;
        DataFim = dataFim;
    }
}

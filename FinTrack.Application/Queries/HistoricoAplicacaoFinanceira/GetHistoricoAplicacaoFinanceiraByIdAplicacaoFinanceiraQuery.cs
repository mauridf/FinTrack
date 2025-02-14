using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;

public record GetHistoricoAplicacaoFinanceiraByIdAplicacaoFinanceiraQuery(Guid AplicacaoFinanceiraId) : IRequest<IEnumerable<HistoricoAplicacaoFinanceira>>;

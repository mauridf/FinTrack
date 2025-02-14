using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;

public record GetDebitosByAplicacaoFinanceiraQuery(Guid AplicacaoFinanceiraId) : IRequest<IEnumerable<HistoricoAplicacaoFinanceira>>;

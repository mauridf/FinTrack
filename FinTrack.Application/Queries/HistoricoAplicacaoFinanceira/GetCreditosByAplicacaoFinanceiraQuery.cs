using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;

public record GetCreditosByAplicacaoFinanceiraQuery(Guid AplicacaoFinanceiraId) : IRequest<IEnumerable<HistoricoAplicacaoFinanceira>>;

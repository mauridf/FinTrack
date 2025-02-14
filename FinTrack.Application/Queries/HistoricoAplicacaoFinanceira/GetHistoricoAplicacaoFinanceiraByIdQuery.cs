using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.HistoricosAplicacoesFinanceiras;

public record GetHistoricoAplicacaoFinanceiraByIdQuery(Guid Id) : IRequest<HistoricoAplicacaoFinanceira>;

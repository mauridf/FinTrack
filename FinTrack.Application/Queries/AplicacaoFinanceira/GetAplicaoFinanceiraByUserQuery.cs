using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.AplicacoesFinanceiras;

public record GetAplicacaoFinanceiraByUserQuery(Guid IdUser) : IRequest<IEnumerable<AplicacaoFinanceira>>;
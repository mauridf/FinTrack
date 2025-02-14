using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.AplicacoesFinanceiras;

public record GetAplicacaoFinanceiraByIdQuery(Guid Id) : IRequest<AplicacaoFinanceira>;

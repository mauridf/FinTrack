using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.AplicacoesFinanceiras;

public record GetAplicacaoFinanceiraByNomeQuery(string nome) : IRequest<AplicacaoFinanceira>;

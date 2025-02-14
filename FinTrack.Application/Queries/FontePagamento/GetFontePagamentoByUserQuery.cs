using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.FontesPagamento;

public record GetFontePagamentoByUserQuery(Guid IdUser) : IRequest<IEnumerable<FontePagamento>>;
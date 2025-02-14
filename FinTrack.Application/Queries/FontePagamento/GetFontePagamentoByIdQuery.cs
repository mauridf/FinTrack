using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.FontesPagamento;

public record GetFontePagamentoByIdQuery(Guid Id) : IRequest<FontePagamento>;
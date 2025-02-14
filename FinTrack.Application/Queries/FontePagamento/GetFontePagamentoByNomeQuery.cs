using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.FontesPagamento;

public record GetFontePagamentoByNomeQuery(string nome) : IRequest<FontePagamento>;

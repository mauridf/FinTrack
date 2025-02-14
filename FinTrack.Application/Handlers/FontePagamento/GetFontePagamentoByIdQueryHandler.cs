using FinTrack.Application.Queries.FontesPagamento;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.FontesPagamento;

public class GetFontePagamentoByIdQueryHandler : IRequestHandler<GetFontePagamentoByIdQuery, FontePagamento>
{
    private readonly IFontePagamentoRepository _fontePagamentoRepository;

    public GetFontePagamentoByIdQueryHandler(IFontePagamentoRepository fontePagamentoRepository)
    {
        _fontePagamentoRepository = fontePagamentoRepository;
    }

    public async Task<FontePagamento> Handle(GetFontePagamentoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _fontePagamentoRepository.GetByIdAsync(request.Id);
    }
}

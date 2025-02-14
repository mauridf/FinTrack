using FinTrack.Application.Queries.FontesPagamento;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.FontesPagamento;

public class GetFontePagamentoByNomeQueryHandler : IRequestHandler<GetFontePagamentoByNomeQuery, FontePagamento>
{
    private readonly IFontePagamentoRepository _fontePagamentoRepository;

    public GetFontePagamentoByNomeQueryHandler(IFontePagamentoRepository fontePagamentoRepository)
    {
        _fontePagamentoRepository = fontePagamentoRepository;
    }

    public async Task<FontePagamento> Handle(GetFontePagamentoByNomeQuery request, CancellationToken cancellationToken)
    {
        return await _fontePagamentoRepository.GetByNomeAsync(request.nome);
    }
}

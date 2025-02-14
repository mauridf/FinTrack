using FinTrack.Application.Commands.FontesPagamento;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.FontesPagamento;

public class DeleteFontePagamentoCommandHandler : IRequestHandler<DeleteFontePagamentoCommand, bool>
{
    private readonly IFontePagamentoRepository _fontePagamentoRepository;

    public DeleteFontePagamentoCommandHandler(IFontePagamentoRepository fontePagamentoRepository)
    {
        _fontePagamentoRepository = fontePagamentoRepository;
    }

    public async Task<bool> Handle(DeleteFontePagamentoCommand request, CancellationToken cancellationToken)
    {
        return await _fontePagamentoRepository.DeleteAsync(request.Id);
    }
}

using FinTrack.Application.Commands.FontesPagamento;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.FontesPagamento;

public class UpdateFontePagamentoCommandHandler : IRequestHandler<UpdateFontePagamentoCommand, FontePagamento>
{
    private readonly IFontePagamentoRepository _fontePagamentoRepository;

    public UpdateFontePagamentoCommandHandler(IFontePagamentoRepository fontePagamentoRepository)
    {
        _fontePagamentoRepository = fontePagamentoRepository;
    }

    public async Task<FontePagamento> Handle(UpdateFontePagamentoCommand request, CancellationToken cancellationToken)
    {
        var fontePagamento = await _fontePagamentoRepository.GetByIdAsync(request.Id);
        if (fontePagamento == null)
        {
            throw new Exception("Fonte de Pagamento não encontrada.");
        }

        fontePagamento.IdUsuario = request.IdUsuario;
        fontePagamento.Nome = request.Nome;
        fontePagamento.Valor = request.Valor;
        fontePagamento.Observacao = request.Observacao;

        return await _fontePagamentoRepository.UpdateAsync(fontePagamento);
    }
}

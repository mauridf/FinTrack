using FinTrack.Application.Commands.FontesPagamento;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.FontesPagamento;

public class CreateFontePagamentoCommandHandler : IRequestHandler<CreateFontePagamentoCommand, FontePagamento>
{
    private readonly IFontePagamentoRepository _fontePagmentoRepository;

    public CreateFontePagamentoCommandHandler(IFontePagamentoRepository fontePagmentoRepository)
    {
        _fontePagmentoRepository = fontePagmentoRepository;
    }

    public async Task<FontePagamento> Handle(CreateFontePagamentoCommand request, CancellationToken cancellationToken)
    {
        var fontePagamento = new FontePagamento
        {
            IdUsuario = request.IdUsuario,
            Nome = request.Nome,
            Valor = request.Valor,
            Observacao = request.Observacao,
            DataRegistro = request.DataRegistro
        };

        return await _fontePagmentoRepository.CreateAsync(fontePagamento);
    }
}

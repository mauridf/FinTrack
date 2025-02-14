using MediatR;

namespace FinTrack.Application.Commands.FontesPagamento;

public class DeleteFontePagamentoCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}

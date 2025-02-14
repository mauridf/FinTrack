using FinTrack.Application.Commands.DebitosMensal;
using FinTrack.Application.Commands.FontesPagamento;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.DebitosMensal;

public class DeleteDebitoMensalCommandHandler : IRequestHandler<DeleteDebitoMensalCommand, bool>
{
    private readonly IDebitoMensalRepository _debitoMensalRepository;

    public DeleteDebitoMensalCommandHandler(IDebitoMensalRepository debitoMensalRepository)
    {
        _debitoMensalRepository = debitoMensalRepository;
    }

    public async Task<bool> Handle(DeleteDebitoMensalCommand request, CancellationToken cancellationToken)
    {
        return await _debitoMensalRepository.DeleteAsync(request.Id);
    }
}

using FinTrack.Application.Commands.ControlesMensal;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal;

public class DeleteControleMensalCommandHandler : IRequestHandler<DeleteControleMensalCommand, bool>
{
    private readonly IControleMensalRepository _controleMensalRepository;

    public DeleteControleMensalCommandHandler(IControleMensalRepository controleMensalRepository)
    {
        _controleMensalRepository = controleMensalRepository;
    }

    public async Task<bool> Handle(DeleteControleMensalCommand request, CancellationToken cancellationToken)
    {
        return await _controleMensalRepository.DeleteAsync(request.Id);
    }
}

using FinTrack.Application.Commands.ControlesMensalDebito;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalDebito;

public class DeleteControleMensalDebitoCommandHandler : IRequestHandler<DeleteControleMensalDebitoCommand, bool>
{
    private readonly IControleMensalDebitoRepository _repository;

    public DeleteControleMensalDebitoCommandHandler(IControleMensalDebitoRepository repository)
    {
        _repository = repository;
    }

    public async Task<bool> Handle(DeleteControleMensalDebitoCommand request, CancellationToken cancellationToken)
    {
        return await _repository.DeleteAsync(request.Id);
    }
}

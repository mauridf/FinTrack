using FinTrack.Application.Queries.ControlesMensalDebito;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalDebito;

public class GetControleMensalDebitoByIdQueryHandler : IRequestHandler<GetControleMensalDebitoByIdQuery, ControleMensalDebito>
{
    private readonly IControleMensalDebitoRepository _repository;

    public GetControleMensalDebitoByIdQueryHandler(IControleMensalDebitoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ControleMensalDebito> Handle(GetControleMensalDebitoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}

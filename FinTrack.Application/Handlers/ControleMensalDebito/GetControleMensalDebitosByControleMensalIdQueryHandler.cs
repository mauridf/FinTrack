using FinTrack.Application.Queries.ControlesMensalDebito;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalDebito;

public class GetControleMensalDebitosByControleMensalIdQueryHandler : IRequestHandler<GetControleMensalDebitosByControleMensalIdQuery, IEnumerable<ControleMensalDebito>>
{
    private readonly IControleMensalDebitoRepository _repository;

    public GetControleMensalDebitosByControleMensalIdQueryHandler(IControleMensalDebitoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ControleMensalDebito>> Handle(GetControleMensalDebitosByControleMensalIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdControleMensalAsync(request.IdControleMensal);
    }
}

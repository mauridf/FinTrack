using FinTrack.Application.Queries.ControlesMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal;

public class GetAllControleMensalQueryHandler : IRequestHandler<GetAllControleMensalQuery, IEnumerable<ControleMensal>>
{
    private readonly IControleMensalRepository _controleMensalRepository;

    public GetAllControleMensalQueryHandler(IControleMensalRepository controleMensalRepository)
    {
        _controleMensalRepository = controleMensalRepository;
    }

    public async Task<IEnumerable<ControleMensal>> Handle(GetAllControleMensalQuery request, CancellationToken cancellationToken)
    {
        return await _controleMensalRepository.GetAllAsync();
    }
}

using FinTrack.Application.Queries.ControlesMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal;

public class GetControleMensalByUsuarioQueryHandler : IRequestHandler<GetControleMensalByUsuarioQuery, IEnumerable<ControleMensal>>
{
    private readonly IControleMensalRepository _controleMensalRepository;

    public GetControleMensalByUsuarioQueryHandler(IControleMensalRepository controleMensalRepository)
    {
        _controleMensalRepository = controleMensalRepository;
    }

    public async Task<IEnumerable<ControleMensal>> Handle(GetControleMensalByUsuarioQuery request, CancellationToken cancellationToken)
    {
        return await _controleMensalRepository.GetByIdUsuarioAsync(request.IdUsuario);
    }
}

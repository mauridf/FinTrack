using FinTrack.Application.Queries.ControlesMensal;
using FinTrack.Domain.DTOs;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal;

public class GetControleMensalResumoQueryHandler : IRequestHandler<GetControleMensalResumoQuery, ControleMensalResumoDto>
{
    private readonly IControleMensalRepository _controleMensalRepository;

    public GetControleMensalResumoQueryHandler(IControleMensalRepository controleMensalRepository)
    {
        _controleMensalRepository = controleMensalRepository;
    }

    public async Task<ControleMensalResumoDto> Handle(GetControleMensalResumoQuery request, CancellationToken cancellationToken)
    {
        return await _controleMensalRepository.GetResumoByPeriodoAsync(request.IdUsuario, request.Mes, request.Ano);
    }
}

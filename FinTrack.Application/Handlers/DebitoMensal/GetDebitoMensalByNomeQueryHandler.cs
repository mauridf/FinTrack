using FinTrack.Application.Queries.DebitosMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.DebitosMensal;

public class GetDebitoMensalByNomeQueryHandler : IRequestHandler<GetDebitoMensalByNomeQuery, DebitoMensal>
{
    private readonly IDebitoMensalRepository _debitoMensalRepository;

    public GetDebitoMensalByNomeQueryHandler(IDebitoMensalRepository debitoMensalRepository)
    {
        _debitoMensalRepository = debitoMensalRepository;
    }

    public async Task<DebitoMensal> Handle(GetDebitoMensalByNomeQuery request, CancellationToken cancellationToken)
    {
        return await _debitoMensalRepository.GetByNomeAsync(request.nome);
    }
}

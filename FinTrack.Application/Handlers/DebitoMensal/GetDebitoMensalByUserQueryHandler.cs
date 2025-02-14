using FinTrack.Application.Queries.DebitosMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.DebitosMensal;

public class GetDebitoMensalByUserQueryHandler : IRequestHandler<GetDebitoMensalByUserQuery, IEnumerable<DebitoMensal>>
{
    private readonly IDebitoMensalRepository _debitoMensalRepository;

    public GetDebitoMensalByUserQueryHandler(IDebitoMensalRepository debitoMensalRepository)
    {
        _debitoMensalRepository = debitoMensalRepository;
    }

    public async Task<IEnumerable<DebitoMensal>> Handle(GetDebitoMensalByUserQuery request, CancellationToken cancellationToken)
    {
        return await _debitoMensalRepository.GetByIdUserAsync(request.IdUser);
    }
}

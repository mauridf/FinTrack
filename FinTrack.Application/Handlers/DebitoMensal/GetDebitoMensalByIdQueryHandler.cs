using FinTrack.Application.Queries.DebitosMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.DebitosMensal;

public class GetDebitoMensalByIdQueryHandler : IRequestHandler<GetDebitoMensalByIdQuery, DebitoMensal>
{
    private readonly IDebitoMensalRepository _debitoMensalRepository;

    public GetDebitoMensalByIdQueryHandler(IDebitoMensalRepository debitoMensalRepository)
    {
        _debitoMensalRepository = debitoMensalRepository;
    }

    public async Task<DebitoMensal> Handle(GetDebitoMensalByIdQuery request, CancellationToken cancellationToken)
    {
        return await _debitoMensalRepository.GetByIdAsync(request.Id);
    }
}

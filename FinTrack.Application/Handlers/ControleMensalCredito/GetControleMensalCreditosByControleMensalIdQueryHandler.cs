using FinTrack.Application.Queries.ControlesMensalCredito;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalCredito;

public class GetControleMensalCreditosByControleMensalIdQueryHandler : IRequestHandler<GetControleMensalCreditosByControleMensalIdQuery, IEnumerable<ControleMensalCredito>>
{
    private readonly IControleMensalCreditoRepository _repository;

    public GetControleMensalCreditosByControleMensalIdQueryHandler(IControleMensalCreditoRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<ControleMensalCredito>> Handle(GetControleMensalCreditosByControleMensalIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdControleMensalAsync(request.IdControleMensal);
    }
}
using FinTrack.Application.Queries.ControlesMensalCredito;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalCredito;

public class GetControleMensalCreditoByIdQueryHandler : IRequestHandler<GetControleMensalCreditoByIdQuery, ControleMensalCredito>
{
    private readonly IControleMensalCreditoRepository _repository;

    public GetControleMensalCreditoByIdQueryHandler(IControleMensalCreditoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ControleMensalCredito> Handle(GetControleMensalCreditoByIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByIdAsync(request.Id);
    }
}
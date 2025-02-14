using FinTrack.Application.Commands.ControlesMensalCredito;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalCredito;

public class CreateControleMensalCreditoCommandHandler : IRequestHandler<CreateControleMensalCreditoCommand, ControleMensalCredito>
{
    private readonly IControleMensalCreditoRepository _repository;

    public CreateControleMensalCreditoCommandHandler(IControleMensalCreditoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ControleMensalCredito> Handle(CreateControleMensalCreditoCommand request, CancellationToken cancellationToken)
    {
        var credito = new ControleMensalCredito
        {
            IdFontePagamento = request.IdFontePagamento,
            IdControleMensal = request.IdControleMensal
        };

        return await _repository.CreateAsync(credito);
    }
}

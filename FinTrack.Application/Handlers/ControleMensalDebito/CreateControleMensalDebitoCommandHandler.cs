using FinTrack.Application.Commands.ControlesMensalDebito;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensalDebito;

public class CreateControleMensalDebitoCommandHandler : IRequestHandler<CreateControleMensalDebitoCommand, ControleMensalDebito>
{
    private readonly IControleMensalDebitoRepository _repository;

    public CreateControleMensalDebitoCommandHandler(IControleMensalDebitoRepository repository)
    {
        _repository = repository;
    }

    public async Task<ControleMensalDebito> Handle(CreateControleMensalDebitoCommand request, CancellationToken cancellationToken)
    {
        var debito = new ControleMensalDebito
        {
            IdDebitoMensal = request.IdDebitoMensal,
            IdControleMensal = request.IdControleMensal
        };

        return await _repository.CreateAsync(debito);
    }
}

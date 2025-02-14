using FinTrack.Application.Commands.ControlesMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal;

public class CreateControleMensalCommandHandler : IRequestHandler<CreateControleMensalCommand, ControleMensal>
{
    private readonly IControleMensalRepository _controleMensalRepository;

    public CreateControleMensalCommandHandler(IControleMensalRepository controleMensalRepository)
    {
        _controleMensalRepository = controleMensalRepository;
    }

    public async Task<ControleMensal> Handle(CreateControleMensalCommand request, CancellationToken cancellationToken)
    {
        var controleMensal = new ControleMensal
        {
            IdUsuario = request.IdUsuario,
            Mes = request.Mes,
            Ano = request.Ano,
            Observacao = request.Observacao,
            TotalCreditos = request.TotalCreditos,
            TotalDebitos = request.TotalDebitos,
            Saldo = request.Saldo,
            DataRegistro = DateTime.UtcNow
        };

        return await _controleMensalRepository.CreateAsync(controleMensal);
    }
}

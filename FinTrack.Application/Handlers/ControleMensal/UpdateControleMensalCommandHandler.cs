using FinTrack.Application.Commands.ControlesMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.ControlesMensal;

public class UpdateControleMensalCommandHandler : IRequestHandler<UpdateControleMensalCommand, ControleMensal>
{
    private readonly IControleMensalRepository _controleMensalRepository;

    public UpdateControleMensalCommandHandler(IControleMensalRepository controleMensalRepository)
    {
        _controleMensalRepository = controleMensalRepository;
    }

    public async Task<ControleMensal> Handle(UpdateControleMensalCommand request, CancellationToken cancellationToken)
    {
        var controleMensal = await _controleMensalRepository.GetByIdAsync(request.Id);
        if (controleMensal == null)
            throw new KeyNotFoundException("Controle Mensal não encontrado.");

        controleMensal.Mes = request.Mes;
        controleMensal.Ano = request.Ano;
        controleMensal.Observacao = request.Observacao;
        controleMensal.TotalCreditos = request.TotalCreditos;
        controleMensal.TotalDebitos = request.TotalDebitos;
        controleMensal.Saldo = request.Saldo;

        return await _controleMensalRepository.UpdateAsync(controleMensal);
    }
}

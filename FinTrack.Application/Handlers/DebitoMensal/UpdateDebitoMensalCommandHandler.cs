using FinTrack.Application.Commands.DebitosMensal;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.DebitosMensal;

public class UpdateDebitoMensalCommandHandler : IRequestHandler<UpdateDebitoMensalCommand, DebitoMensal>
{
    private readonly IDebitoMensalRepository _debitoMensalRepository;

    public UpdateDebitoMensalCommandHandler(IDebitoMensalRepository debitoMensalRepository)
    {
        _debitoMensalRepository = debitoMensalRepository;
    }

    public async Task<DebitoMensal> Handle(UpdateDebitoMensalCommand request, CancellationToken cancellationToken)
    {
        var debitoMensal = await _debitoMensalRepository.GetByIdAsync(request.Id);
        if(debitoMensal == null)
        {
            throw new Exception("Débito Mensal não encontrado");
        }

        debitoMensal.IdUsuario = request.IdUsuario;
        debitoMensal.Nome = request.Nome;
        debitoMensal.Valor = request.Valor;
        debitoMensal.Observacao = request.Observacao;
        debitoMensal.Pago = request.Pago;

        return await _debitoMensalRepository.UpdateAsync(debitoMensal);
    }
}

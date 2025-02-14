using FinTrack.Application.Commands.DebitosMensal;
using FinTrack.Application.Commands.FontesPagamento;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.DebitosMensal;

public class CreateDebitoMensalCommandHandler : IRequestHandler<CreateDebitoMensalCommand, DebitoMensal>
{
    private readonly IDebitoMensalRepository _debitoMensalRepository;

    public CreateDebitoMensalCommandHandler(IDebitoMensalRepository debitoMensalRepository)
    {
        _debitoMensalRepository = debitoMensalRepository;
    }

    public async Task<DebitoMensal> Handle(CreateDebitoMensalCommand request, CancellationToken cancellationToken)
    {
        var debitoMensal = new DebitoMensal
        {
            IdUsuario = request.IdUsuario,
            Nome = request.Nome,
            Valor = request.Valor,
            Observacao = request.Observacao,
            DataRegistro = request.DataRegistro,
            Pago = request.Pago
        };

        return await _debitoMensalRepository.CreateAsync(debitoMensal);
    }
}

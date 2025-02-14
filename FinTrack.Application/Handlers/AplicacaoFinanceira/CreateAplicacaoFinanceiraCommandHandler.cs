using FinTrack.Application.Commands.AplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.AplicacoesFinanceiras;

public class CreateAplicacaoFinanceiraCommandHandler : IRequestHandler<CreateAplicacaoFinanceiraCommand, AplicacaoFinanceira>
{
    private readonly IAplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;

    public CreateAplicacaoFinanceiraCommandHandler(IAplicacaoFinanceiraRepository aplicacaoFinanceiraRepository)
    {
        _aplicacaoFinanceiraRepository = aplicacaoFinanceiraRepository;
    }

    public async Task<AplicacaoFinanceira> Handle(CreateAplicacaoFinanceiraCommand request, CancellationToken cancellationToken)
    {
        var aplicacaoFinanceira = new AplicacaoFinanceira
        {
            IdUsuario = request.IdUsuario,
            Nome = request.Nome,
            Valor = request.Valor,
            Observacao = request.Observacao,
            DataRegistro = request.DataRegistro
        };

        return await _aplicacaoFinanceiraRepository.CreateAsync(aplicacaoFinanceira);
    }
}

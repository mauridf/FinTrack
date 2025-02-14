using FinTrack.Application.Commands.AplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.AplicacoesFinanceiras;

public class UpdateAplicacaoFinanceiraCommandHandler : IRequestHandler<UpdateAplicacaoFinanceiraCommand, AplicacaoFinanceira>
{
    private readonly IAplicacaoFinanceiraRepository _aplicacaoFinanceiraRepository;

    public UpdateAplicacaoFinanceiraCommandHandler(IAplicacaoFinanceiraRepository aplicacaoFinanceiraRepository)
    {
        _aplicacaoFinanceiraRepository = aplicacaoFinanceiraRepository;
    }

    public async Task<AplicacaoFinanceira> Handle(UpdateAplicacaoFinanceiraCommand request, CancellationToken cancellationToken)
    {
        var aplicacaoFinanceira = await _aplicacaoFinanceiraRepository.GetByIdAsync(request.Id);
        if (aplicacaoFinanceira == null)
        {
            throw new Exception("Aplicação Financeira não encontrada");
        }

        aplicacaoFinanceira.IdUsuario = request.IdUsuario;
        aplicacaoFinanceira.Nome = request.Nome;
        aplicacaoFinanceira.Valor = request.Valor;
        aplicacaoFinanceira.Observacao = request.Observacao;

        return await _aplicacaoFinanceiraRepository.UpdateAsync(aplicacaoFinanceira);
    }
}

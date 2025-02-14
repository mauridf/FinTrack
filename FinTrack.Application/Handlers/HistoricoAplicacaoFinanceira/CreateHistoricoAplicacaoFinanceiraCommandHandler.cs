using FinTrack.Application.Commands.HistoricosAplicacoesFinanceiras;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.HistoricosAplicacoesFinanceiras;
public class CreateHistoricoAplicacaoFinanceiraCommandHandler
    : IRequestHandler<CreateHistoricoAplicacaoFinanceiraCommand, HistoricoAplicacaoFinanceira>
{
    private readonly IHistoricoAplicacaoFinanceiraRepository _historicoRepository;

    public CreateHistoricoAplicacaoFinanceiraCommandHandler(IHistoricoAplicacaoFinanceiraRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task<HistoricoAplicacaoFinanceira> Handle(CreateHistoricoAplicacaoFinanceiraCommand request, CancellationToken cancellationToken)
    {
        var historico = new HistoricoAplicacaoFinanceira
        {
            AplicacaoFinanceiraId = request.AplicacaoFinanceiraId,
            ValorHistorico = request.ValorHistorico,
            Credito = request.Credito,
            Debito = request.Debito,
            DataRegistro = DateTime.UtcNow
        };

        return await _historicoRepository.CreateAsync(historico);
    }
}

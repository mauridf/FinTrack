using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.HistoricosAplicacoesFinanceiras;

public record CreateHistoricoAplicacaoFinanceiraCommand(
    Guid AplicacaoFinanceiraId,
    DateTime DataRegistro,
    int ValorHistorico,
    bool Credito,
    bool Debito
) : IRequest<HistoricoAplicacaoFinanceira>;

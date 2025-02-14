using FinTrack.Domain.DTOs;
using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IHistoricoAplicacaoFinanceiraRepository
{
    Task<HistoricoAplicacaoFinanceira> CreateAsync(HistoricoAplicacaoFinanceira historico);
    Task<HistoricoAplicacaoFinanceira?> GetByIdAsync(Guid id);
    Task<IEnumerable<HistoricoAplicacaoFinanceira>> GetByIdAplicacaoFinanceiraAsync(Guid aplicacaoFinanceiraId);
    Task<IEnumerable<HistoricoAplicacaoFinanceira>> GetCreditosByAplicacaoFinanceiraAsync(Guid aplicacaoFinanceiraId);
    Task<IEnumerable<HistoricoAplicacaoFinanceira>> GetDebitosByAplicacaoFinanceiraAsync(Guid aplicacaoFinanceiraId);
    public Task<ResumoAplicacaoFinanceiraDto> GetResumoByAplicacaoEPeriodoAsync(Guid idUsuario, Guid aplicacaoFinanceiraId, DateTime dataInicio, DateTime dataFim);

}
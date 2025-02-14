using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IAplicacaoFinanceiraRepository
{
    Task<AplicacaoFinanceira> GetByIdAsync(Guid id);
    Task<AplicacaoFinanceira> GetByNomeAsync(string nome);
    Task<IEnumerable<AplicacaoFinanceira>> GetByIdUserAsync(Guid idUser);
    Task<AplicacaoFinanceira> CreateAsync(AplicacaoFinanceira aplicacaoFinanceira);
    Task<AplicacaoFinanceira> UpdateAsync(AplicacaoFinanceira aplicacaoFinanceira);
    Task<bool> DeleteAsync(Guid id);
}

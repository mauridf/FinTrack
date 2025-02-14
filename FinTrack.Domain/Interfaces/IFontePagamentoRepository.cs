using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IFontePagamentoRepository
{
    Task<FontePagamento> GetByIdAsync(Guid id);
    Task<FontePagamento> GetByNomeAsync(string nome);
    Task<IEnumerable<FontePagamento>> GetByIdUserAsync(Guid idUser);
    Task<FontePagamento> CreateAsync(FontePagamento fontePagamento);
    Task<FontePagamento> UpdateAsync(FontePagamento fontePagamento);
    Task<bool> DeleteAsync(Guid id);
}

using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IDebitoMensalRepository
{
    Task<DebitoMensal> GetByIdAsync(Guid id);
    Task<DebitoMensal> GetByNomeAsync(string nome);
    Task<IEnumerable<DebitoMensal>> GetByIdUserAsync(Guid idUser);
    Task<DebitoMensal> CreateAsync(DebitoMensal debitoMensal);
    Task<DebitoMensal> UpdateAsync(DebitoMensal debitoMensal);
    Task<bool> DeleteAsync(Guid id);
}

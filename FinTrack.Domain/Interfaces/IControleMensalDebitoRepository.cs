using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IControleMensalDebitoRepository
{
    Task<ControleMensalDebito> GetByIdAsync(Guid id);
    Task<IEnumerable<ControleMensalDebito>> GetByIdControleMensalAsync(Guid idControleMensal);
    Task<ControleMensalDebito> CreateAsync(ControleMensalDebito controleMensalDebito);
    Task<bool> DeleteAsync(Guid id);
}

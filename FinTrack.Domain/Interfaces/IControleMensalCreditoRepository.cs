using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IControleMensalCreditoRepository
{
    Task<ControleMensalCredito> GetByIdAsync(Guid id);
    Task<IEnumerable<ControleMensalCredito>> GetByIdControleMensalAsync(Guid idControleMensal);
    Task<ControleMensalCredito> CreateAsync(ControleMensalCredito controleMensalCredito);
    Task<bool> DeleteAsync(Guid id);
}

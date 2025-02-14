using FinTrack.Domain.DTOs;
using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IControleMensalRepository
{
    Task<ControleMensal> GetByIdAsync(Guid id);
    Task<IEnumerable<ControleMensal>> GetByIdUsuarioAsync(Guid idUsuario);
    Task<IEnumerable<ControleMensal>> GetAllAsync();
    Task<ControleMensal> CreateAsync(ControleMensal controleMensal);
    Task<ControleMensal> UpdateAsync(ControleMensal controleMensal);
    Task<bool> DeleteAsync(Guid id);
    Task<ControleMensalResumoDto> GetResumoByPeriodoAsync(Guid idUsuario, string mes, string ano);
}

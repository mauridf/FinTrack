using FinTrack.Domain.Entities;

namespace FinTrack.Domain.Interfaces;

public interface IUserRepository
{
    Task<Usuario> GetByIdAsync(Guid id);
    Task<Usuario> GetByEmailAsync(string email);
    Task<Usuario> CreateAsync(Usuario usuario);
    Task<Usuario> UpdateAsync(Usuario usuario);
    Task<bool> DeleteAsync(Guid userId);
}

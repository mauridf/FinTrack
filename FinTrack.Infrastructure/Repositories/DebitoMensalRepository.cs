using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositories;

public class DebitoMensalRepository : IDebitoMensalRepository
{
    private readonly ApplicationDbContext _context;

    public DebitoMensalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<DebitoMensal> CreateAsync(DebitoMensal debitoMensal)
    {
        _context.DebitosMensais.AddAsync(debitoMensal);
        await _context.SaveChangesAsync();
        return debitoMensal;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var debitoMensal = await _context.DebitosMensais.FindAsync(id);
        if (debitoMensal == null) return false;

        _context.DebitosMensais.Remove(debitoMensal);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<DebitoMensal> GetByIdAsync(Guid id)
    {
        return await _context.DebitosMensais.FindAsync(id);
    }

    public async Task<IEnumerable<DebitoMensal>> GetByIdUserAsync(Guid idUser)
    {
        return await _context.DebitosMensais
            .Where(d => d.IdUsuario == idUser)
            .ToListAsync();
    }

    public async Task<DebitoMensal> GetByNomeAsync(string nome)
    {
        return await _context.DebitosMensais.FirstOrDefaultAsync(d => d.Nome == nome);
    }

    public async Task<DebitoMensal> UpdateAsync(DebitoMensal debitoMensal)
    {
        _context.DebitosMensais.Update(debitoMensal);
        await _context.SaveChangesAsync();
        return debitoMensal;
    }
}

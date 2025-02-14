using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositories;

public class AplicacaoFinanceiraRepository : IAplicacaoFinanceiraRepository
{
    private readonly ApplicationDbContext _context;

    public AplicacaoFinanceiraRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async  Task<AplicacaoFinanceira> CreateAsync(AplicacaoFinanceira aplicacaoFinanceira)
    {
        _context.AplicacoesFinanceiras.AddAsync(aplicacaoFinanceira);
        await _context.SaveChangesAsync();
        return aplicacaoFinanceira;
    }

    public async  Task<bool> DeleteAsync(Guid id)
    {
        var aplicacaoFinanceira = await _context.AplicacoesFinanceiras.FindAsync(id);
        if (aplicacaoFinanceira == null) return false;

        _context.AplicacoesFinanceiras.Remove(aplicacaoFinanceira);
        await _context.SaveChangesAsync();
        return true;
    }

    public async  Task<AplicacaoFinanceira> GetByIdAsync(Guid id)
    {
        return await _context.AplicacoesFinanceiras.FindAsync(id);
    }

    public async  Task<IEnumerable<AplicacaoFinanceira>> GetByIdUserAsync(Guid idUser)
    {
        return await _context.AplicacoesFinanceiras
            .Where(a => a.IdUsuario == idUser)
            .ToListAsync();
    }

    public async  Task<AplicacaoFinanceira> GetByNomeAsync(string nome)
    {
        return await _context.AplicacoesFinanceiras.FirstOrDefaultAsync(a => a.Nome == nome);
    }

    public async  Task<AplicacaoFinanceira> UpdateAsync(AplicacaoFinanceira aplicacaoFinanceira)
    {
        _context.AplicacoesFinanceiras.Update(aplicacaoFinanceira);
        await _context.SaveChangesAsync();
        return aplicacaoFinanceira;
    }
}

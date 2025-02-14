using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace FinTrack.Infrastructure.Repositories;

public class FontePagamentoRepository : IFontePagamentoRepository
{
    private readonly ApplicationDbContext _context;

    public FontePagamentoRepository(ApplicationDbContext context)
    {  
        _context = context; 
    }

    public async Task<FontePagamento> CreateAsync(FontePagamento fontePagamento)
    {
        _context.FontesPagamento.AddAsync(fontePagamento);
        await _context.SaveChangesAsync();
        return fontePagamento;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var fontePagamento = await _context.FontesPagamento.FindAsync(id);
        if (fontePagamento == null) return false;

        _context.FontesPagamento.Remove(fontePagamento);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<FontePagamento> GetByIdAsync(Guid id)
    {
        return await _context.FontesPagamento.FindAsync(id);
    }

    public async Task<IEnumerable<FontePagamento>> GetByIdUserAsync(Guid idUser)
    {
        return await _context.FontesPagamento
            .Where(f => f.IdUsuario == idUser)
            .ToListAsync();
    }

    public async Task<FontePagamento> GetByNomeAsync(string nome)
    {
        return await _context.FontesPagamento.FirstOrDefaultAsync(f => f.Nome == nome);
    }

    public async Task<FontePagamento> UpdateAsync(FontePagamento fontePagamento)
    {
        _context.FontesPagamento.Update(fontePagamento);
        await _context.SaveChangesAsync();
        return fontePagamento;
    }
}

using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositories;

public class ControleMensalDebitoRepository : IControleMensalDebitoRepository
{
    private readonly ApplicationDbContext _context;

    public ControleMensalDebitoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ControleMensalDebito> CreateAsync(ControleMensalDebito controleMensalDebito)
    {
        await _context.ControleMensalDebitos.AddAsync(controleMensalDebito);
        await _context.SaveChangesAsync();
        return controleMensalDebito;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var controleMensalDebito = await _context.ControleMensalDebitos.FindAsync(id);
        if (controleMensalDebito == null) return false;

        _context.ControleMensalDebitos.Remove(controleMensalDebito);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ControleMensalDebito> GetByIdAsync(Guid id)
    {
        return await _context.ControleMensalDebitos.FindAsync(id);
    }

    public async Task<IEnumerable<ControleMensalDebito>> GetByIdControleMensalAsync(Guid idControleMensal)
    {
        return await _context.ControleMensalDebitos
            .Where(c => c.IdControleMensal == idControleMensal)
            .ToListAsync();
    }
}

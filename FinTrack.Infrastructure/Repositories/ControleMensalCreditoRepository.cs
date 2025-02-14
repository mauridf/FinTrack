using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositories;

public class ControleMensalCreditoRepository : IControleMensalCreditoRepository
{
    private readonly ApplicationDbContext _context;

    public ControleMensalCreditoRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ControleMensalCredito> CreateAsync(ControleMensalCredito controleMensalCredito)
    {
        await _context.ControleMensalCreditos.AddAsync(controleMensalCredito);
        await _context.SaveChangesAsync();
        return controleMensalCredito;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var controleMensalCredito = await _context.ControleMensalCreditos.FindAsync(id);
        if (controleMensalCredito == null) return false;

        _context.ControleMensalCreditos.Remove(controleMensalCredito);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<ControleMensalCredito> GetByIdAsync(Guid id)
    {
        return await _context.ControleMensalCreditos.FindAsync(id);
    }

    public async Task<IEnumerable<ControleMensalCredito>> GetByIdControleMensalAsync(Guid idControleMensal)
    {
        return await _context.ControleMensalCreditos
            .Where(c => c.IdControleMensal == idControleMensal)
            .ToListAsync();
    }
}
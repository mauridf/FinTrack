using FinTrack.Domain.DTOs;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositories;

public class ControleMensalRepository : IControleMensalRepository
{
    private readonly ApplicationDbContext _context;

    public ControleMensalRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ControleMensal> CreateAsync(ControleMensal controleMensal)
    {
        await _context.ControlesMensais.AddAsync(controleMensal);
        await _context.SaveChangesAsync();
        return controleMensal;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var controleMensal = await _context.ControlesMensais.FindAsync(id);
        if (controleMensal == null) return false;

        _context.ControlesMensais.Remove(controleMensal);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<ControleMensal>> GetAllAsync()
    {
        return await _context.ControlesMensais
            .Include(c => c.ControleMensalCreditos)
            .Include(c => c.ControleMensalDebitos)
            .ToListAsync();
    }

    public async Task<ControleMensal> GetByIdAsync(Guid id)
    {
        return await _context.ControlesMensais
            .Include(c => c.ControleMensalCreditos)
            .Include(c => c.ControleMensalDebitos)
            .FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<IEnumerable<ControleMensal>> GetByIdUsuarioAsync(Guid idUsuario)
    {
        return await _context.ControlesMensais
            .Where(c => c.IdUsuario == idUsuario)
            .ToListAsync();
    }

    public async Task<ControleMensalResumoDto> GetResumoByPeriodoAsync(Guid idUsuario, string mes, string ano)
    {
        var controle = await _context.ControlesMensais
            .Where(c => c.IdUsuario == idUsuario && c.Mes == mes && c.Ano == ano)
            .Select(c => new ControleMensalResumoDto
            {
                TotalCreditos = c.TotalCreditos,
                TotalDebitos = c.TotalDebitos,
                Saldo = c.TotalCreditos - c.TotalDebitos
            })
            .FirstOrDefaultAsync();

        return controle ?? new ControleMensalResumoDto(); // Retorna um DTO vazio caso não encontre dados
    }

    public async Task<ControleMensal> UpdateAsync(ControleMensal controleMensal)
    {
        _context.ControlesMensais.Update(controleMensal);
        await _context.SaveChangesAsync();
        return controleMensal;
    }
}

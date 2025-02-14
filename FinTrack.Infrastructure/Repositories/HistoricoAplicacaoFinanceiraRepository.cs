using FinTrack.Domain.DTOs;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Repositories;

public class HistoricoAplicacaoFinanceiraRepository : IHistoricoAplicacaoFinanceiraRepository
{
    private readonly ApplicationDbContext _context;

    public HistoricoAplicacaoFinanceiraRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<HistoricoAplicacaoFinanceira> CreateAsync(HistoricoAplicacaoFinanceira historico)
    {
        await _context.HistoricoAplicacoesFinanceiras.AddAsync(historico);
        await _context.SaveChangesAsync();
        return historico;
    }

    public async Task<HistoricoAplicacaoFinanceira?> GetByIdAsync(Guid id)
    {
        return await _context.HistoricoAplicacoesFinanceiras.FindAsync(id);
    }

    public async Task<IEnumerable<HistoricoAplicacaoFinanceira>> GetByIdAplicacaoFinanceiraAsync(Guid aplicacaoFinanceiraId)
    {
        return await _context.HistoricoAplicacoesFinanceiras
            .Where(h => h.AplicacaoFinanceiraId == aplicacaoFinanceiraId)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoricoAplicacaoFinanceira>> GetCreditosByAplicacaoFinanceiraAsync(Guid aplicacaoFinanceiraId)
    {
        return await _context.HistoricoAplicacoesFinanceiras
            .Where(h => h.AplicacaoFinanceiraId == aplicacaoFinanceiraId && h.Credito == true && h.Debito == false)
            .ToListAsync();
    }

    public async Task<IEnumerable<HistoricoAplicacaoFinanceira>> GetDebitosByAplicacaoFinanceiraAsync(Guid aplicacaoFinanceiraId)
    {
        return await _context.HistoricoAplicacoesFinanceiras
            .Where(h => h.AplicacaoFinanceiraId == aplicacaoFinanceiraId && h.Credito == false && h.Debito == true)
            .ToListAsync();
    }

    public async Task<ResumoAplicacaoFinanceiraDto> GetResumoByAplicacaoEPeriodoAsync(Guid idUsuario, Guid aplicacaoFinanceiraId, DateTime dataInicio, DateTime dataFim)
    {
        var historico = await _context.HistoricoAplicacoesFinanceiras
            .Where(h => h.AplicacaoFinanceira.IdUsuario == idUsuario &&
                        h.AplicacaoFinanceiraId == aplicacaoFinanceiraId &&
                        h.DataRegistro >= dataInicio &&
                        h.DataRegistro <= dataFim)
            .ToListAsync();

        var totalCreditos = historico.Where(h => h.Credito).Sum(h => h.ValorHistorico);
        var totalDebitos = historico.Where(h => h.Debito).Sum(h => h.ValorHistorico);
        var saldo = totalCreditos - totalDebitos;

        return new ResumoAplicacaoFinanceiraDto
        {
            AplicacaoFinanceiraId = aplicacaoFinanceiraId,
            DataInicio = dataInicio,
            DataFim = dataFim,
            TotalCreditos = totalCreditos,
            TotalDebitos = totalDebitos,
            Saldo = saldo
        };
    }

}

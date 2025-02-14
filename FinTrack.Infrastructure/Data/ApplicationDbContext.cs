using FinTrack.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinTrack.Infrastructure.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<FontePagamento> FontesPagamento { get; set; }
    public DbSet<DebitoMensal> DebitosMensais { get; set; }
    public DbSet<ControleMensal> ControlesMensais { get; set; }
    public DbSet<ControleMensalCredito> ControleMensalCreditos { get; set; }
    public DbSet<ControleMensalDebito> ControleMensalDebitos { get; set; }
    public DbSet<AplicacaoFinanceira> AplicacoesFinanceiras { get; set; }
    public DbSet<HistoricoAplicacaoFinanceira> HistoricoAplicacoesFinanceiras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Relacionamento Usuario -> Fontes de Pagamento
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.FontesPagamento)
            .WithOne(f => f.Usuario)
            .HasForeignKey(f => f.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Usuario -> Débitos Mensais
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.DebitosMensais)
            .WithOne(d => d.Usuario)
            .HasForeignKey(d => d.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Usuario -> Controles Mensais
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.ControlesMensais)
            .WithOne(c => c.Usuario)
            .HasForeignKey(c => c.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Usuario -> Aplicações Financeiras
        modelBuilder.Entity<Usuario>()
            .HasMany(u => u.AplicacoesFinanceiras)
            .WithOne(a => a.Usuario)
            .HasForeignKey(a => a.IdUsuario)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento FontePagamento -> ControleMensalCredito (Muitos-para-Muitos)
        modelBuilder.Entity<ControleMensalCredito>()
            .HasOne(cmc => cmc.FontesPagamento)
            .WithMany(fp => fp.ControleMensalCreditos)
            .HasForeignKey(cmc => cmc.IdFontePagamento)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ControleMensalCredito>()
            .HasOne(cmc => cmc.ControleMensal)
            .WithMany(cm => cm.ControleMensalCreditos)
            .HasForeignKey(cmc => cmc.IdControleMensal)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento DébitoMensal -> ControleMensalDebito (Muitos-para-Muitos)
        modelBuilder.Entity<ControleMensalDebito>()
            .HasOne(cmd => cmd.DebitosMensal)
            .WithMany(dm => dm.ControleMensalDebitos)
            .HasForeignKey(cmd => cmd.IdDebitoMensal)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ControleMensalDebito>()
            .HasOne(cmd => cmd.ControleMensal)
            .WithMany(cm => cm.ControleMensalDebitos)
            .HasForeignKey(cmd => cmd.IdControleMensal)
            .OnDelete(DeleteBehavior.Cascade);

        // Relacionamento Aplicação Financeira -> Histórico de Aplicação Financeira
        modelBuilder.Entity<HistoricoAplicacaoFinanceira>()
            .HasOne(haf => haf.AplicacaoFinanceira)
            .WithMany(af => af.Historico)
            .HasForeignKey(haf => haf.AplicacaoFinanceiraId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
namespace FinTrack.Domain.Entities;

public class HistoricoAplicacaoFinanceira : BaseEntity
{
    public Guid AplicacaoFinanceiraId { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    public int ValorHistorico { get; set; }
    public bool Credito { get; set; }
    public bool Debito { get; set; }
    public AplicacaoFinanceira? AplicacaoFinanceira { get; set; }
}

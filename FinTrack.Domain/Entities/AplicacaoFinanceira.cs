namespace FinTrack.Domain.Entities;

public class AplicacaoFinanceira : BaseEntity
{
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    public Usuario? Usuario { get; set; } = null!;

    public ICollection<HistoricoAplicacaoFinanceira>? Historico { get; set; } = new List<HistoricoAplicacaoFinanceira>();
}

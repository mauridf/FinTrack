namespace FinTrack.Domain.Entities;

public class Usuario : BaseEntity
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string SenhaHash { get; set; } = string.Empty;
    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public bool Ativo { get; set; } = true;

    public ICollection<FontePagamento>? FontesPagamento { get; set; } = new List<FontePagamento>();
    public ICollection<DebitoMensal>? DebitosMensais { get; set; } = new List<DebitoMensal>();
    public ICollection<ControleMensal>? ControlesMensais { get; set; } = new List<ControleMensal>();
    public ICollection<AplicacaoFinanceira>? AplicacoesFinanceiras { get; set; } = new List<AplicacaoFinanceira>();
}

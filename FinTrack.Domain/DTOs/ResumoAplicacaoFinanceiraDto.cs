namespace FinTrack.Domain.DTOs;

public class ResumoAplicacaoFinanceiraDto
{
    public Guid AplicacaoFinanceiraId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime DataFim { get; set; }
    public decimal TotalCreditos { get; set; }
    public decimal TotalDebitos { get; set; }
    public decimal Saldo { get; set; }
}

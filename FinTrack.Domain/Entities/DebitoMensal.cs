namespace FinTrack.Domain.Entities;

public class DebitoMensal : BaseEntity
{
    public Guid IdUsuario { get; set; }
    public string Nome { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string? Observacao { get; set; }
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
    public bool Pago { get; set; } = false;

    public Usuario? Usuario { get; set; } = null!;

    public ICollection<ControleMensalDebito>? ControleMensalDebitos { get; set; } = new List<ControleMensalDebito>();
}

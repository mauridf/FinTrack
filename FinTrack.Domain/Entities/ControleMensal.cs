namespace FinTrack.Domain.Entities;

public class ControleMensal : BaseEntity
{
    public Guid IdUsuario { get; set; }
    public string Mes {  get; set; }
    public string Ano { get; set; }
    public string? Observacao { get; set; }
    public decimal TotalCreditos { get; set; } = 0;
    public decimal TotalDebitos { get; set;} = 0;
    public decimal Saldo { get; set; } = 0;
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    public Usuario? Usuario { get; set; } = null!;

    public ICollection<ControleMensalCredito>? ControleMensalCreditos { get; set; } = new List<ControleMensalCredito>();
    public ICollection<ControleMensalDebito>? ControleMensalDebitos { get; set; } = new List<ControleMensalDebito>();
}

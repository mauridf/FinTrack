namespace FinTrack.Domain.Entities;

public class ControleMensalDebito : BaseEntity
{
    public Guid IdDebitoMensal { get; set; }
    public Guid IdControleMensal { get; set; }

    public DebitoMensal? DebitosMensal { get; set; }
    public ControleMensal? ControleMensal { get; set; }
}

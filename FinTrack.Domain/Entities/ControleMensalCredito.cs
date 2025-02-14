namespace FinTrack.Domain.Entities;

public class ControleMensalCredito : BaseEntity
{
    public Guid IdFontePagamento { get; set; }
    public Guid IdControleMensal {  get; set; }

    public FontePagamento? FontesPagamento { get; set; }
    public ControleMensal? ControleMensal { get; set; }
}

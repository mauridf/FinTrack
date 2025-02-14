using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.ControlesMensalCredito;

public class CreateControleMensalCreditoCommand : IRequest<ControleMensalCredito>
{
    public Guid IdFontePagamento { get; set; }
    public Guid IdControleMensal { get; set; }

    public CreateControleMensalCreditoCommand(Guid idFontePagamento, Guid idControleMensal)
    {
        IdFontePagamento = idFontePagamento;
        IdControleMensal = idControleMensal;
    }
}

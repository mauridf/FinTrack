using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.ControlesMensalDebito;

public class CreateControleMensalDebitoCommand : IRequest<ControleMensalDebito>
{
    public Guid IdDebitoMensal { get; set; }
    public Guid IdControleMensal { get; set; }

    public CreateControleMensalDebitoCommand(Guid idDebitoMensal, Guid idControleMensal)
    {
        IdDebitoMensal = idDebitoMensal;
        IdControleMensal = idControleMensal;
    }
}

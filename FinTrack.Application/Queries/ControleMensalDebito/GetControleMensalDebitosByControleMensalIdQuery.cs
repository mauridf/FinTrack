using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensalDebito;

public class GetControleMensalDebitosByControleMensalIdQuery : IRequest<IEnumerable<ControleMensalDebito>>
{
    public Guid IdControleMensal { get; set; }

    public GetControleMensalDebitosByControleMensalIdQuery(Guid idControleMensal)
    {
        IdControleMensal = idControleMensal;
    }
}

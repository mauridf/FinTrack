using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensalCredito;

public class GetControleMensalCreditosByControleMensalIdQuery : IRequest<IEnumerable<ControleMensalCredito>>
{
    public Guid IdControleMensal { get; set; }

    public GetControleMensalCreditosByControleMensalIdQuery(Guid idControleMensal)
    {
        IdControleMensal = idControleMensal;
    }
}

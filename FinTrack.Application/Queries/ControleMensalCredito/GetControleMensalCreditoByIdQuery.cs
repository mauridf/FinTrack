using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensalCredito;

public class GetControleMensalCreditoByIdQuery : IRequest<ControleMensalCredito>
{
    public Guid Id { get; set; }

    public GetControleMensalCreditoByIdQuery(Guid id)
    {
        Id = id;
    }
}

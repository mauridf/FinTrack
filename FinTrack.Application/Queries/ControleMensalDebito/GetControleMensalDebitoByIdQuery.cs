using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensalDebito;

public class GetControleMensalDebitoByIdQuery : IRequest<ControleMensalDebito>
{
    public Guid Id { get; set; }

    public GetControleMensalDebitoByIdQuery(Guid id)
    {
        Id = id;
    }
}

using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensal;

public class GetControleMensalByIdQuery : IRequest<ControleMensal>
{
    public Guid Id { get; set; }

    public GetControleMensalByIdQuery(Guid id)
    {
        Id = id;
    }
}

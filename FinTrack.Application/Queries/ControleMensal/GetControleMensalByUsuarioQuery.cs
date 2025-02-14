using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensal;

public class GetControleMensalByUsuarioQuery : IRequest<IEnumerable<ControleMensal>>
{
    public Guid IdUsuario { get; set; }

    public GetControleMensalByUsuarioQuery(Guid idUsuario)
    {
        IdUsuario = idUsuario;
    }
}

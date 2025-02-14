using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.ControlesMensal;

public class GetAllControleMensalQuery : IRequest<IEnumerable<ControleMensal>>
{
}

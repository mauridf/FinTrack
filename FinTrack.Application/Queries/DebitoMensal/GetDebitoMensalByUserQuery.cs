using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.DebitosMensal;

public record GetDebitoMensalByUserQuery(Guid IdUser) : IRequest<IEnumerable<DebitoMensal>>;

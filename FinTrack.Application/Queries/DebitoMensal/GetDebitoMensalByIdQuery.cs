using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.DebitosMensal;

public record GetDebitoMensalByIdQuery(Guid Id) : IRequest<DebitoMensal>;
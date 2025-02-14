using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.DebitosMensal;

public record GetDebitoMensalByNomeQuery(string nome) : IRequest<DebitoMensal>;
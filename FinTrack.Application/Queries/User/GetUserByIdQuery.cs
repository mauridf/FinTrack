using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.User;

public record GetUserByIdQuery(Guid Id) : IRequest<Usuario>;

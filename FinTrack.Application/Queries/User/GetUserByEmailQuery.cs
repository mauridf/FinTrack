using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Queries.User;

public record GetUserByEmailQuery(string Email) : IRequest<Usuario>;


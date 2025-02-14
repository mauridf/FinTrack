using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.User;

public class UpdateUserCommand : IRequest<Usuario>
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
}


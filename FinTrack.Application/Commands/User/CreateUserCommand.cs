using FinTrack.Domain.Entities;
using MediatR;

namespace FinTrack.Application.Commands.User;

public class CreateUserCommand : IRequest<Usuario>
{
    public string Nome { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
}

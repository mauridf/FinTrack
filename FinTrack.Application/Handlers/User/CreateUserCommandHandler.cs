using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;
using BCrypt.Net;
using FinTrack.Application.Commands.User;

namespace FinTrack.Application.Handlers.User;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Usuario>
{
    private readonly IUserRepository _userRepository;

    public CreateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Usuario> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var usuario = new Usuario
        {
            Nome = request.Nome,
            Email = request.Email,
            SenhaHash = BCrypt.Net.BCrypt.HashPassword(request.Senha) // Gera o hash da senha
        };

        return await _userRepository.CreateAsync(usuario);
    }
}
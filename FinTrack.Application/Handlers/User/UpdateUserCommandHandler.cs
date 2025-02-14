using FinTrack.Application.Commands.User;
using FinTrack.Domain.Entities;
using FinTrack.Domain.Interfaces;
using MediatR;

namespace FinTrack.Application.Handlers.User;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Usuario>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Usuario> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var usuario = await _userRepository.GetByIdAsync(request.Id);
        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado.");
        }

        usuario.Nome = request.Nome;
        usuario.Email = request.Email;

        return await _userRepository.UpdateAsync(usuario);
    }
}
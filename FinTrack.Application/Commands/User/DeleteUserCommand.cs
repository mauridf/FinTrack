using MediatR;

namespace FinTrack.Application.Commands.User;

public class DeleteUserCommand : IRequest<bool>
{
    public Guid Id { get; set; }
}


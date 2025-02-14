using FinTrack.Application.Commands.User;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Application.Extensions;

public static class MediatRExtensions
{
    public static IServiceCollection AddApplicationMediatR(this IServiceCollection services)
    {
        // Registra todos os handlers do assembly onde está o CreateUserCommand
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateUserCommand).Assembly));
        return services;
    }
}
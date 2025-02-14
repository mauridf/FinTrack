using FinTrack.Domain.Interfaces;
using FinTrack.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace FinTrack.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFontePagamentoRepository, FontePagamentoRepository>();
        services.AddScoped<IDebitoMensalRepository, DebitoMensalRepository>();
        services.AddScoped<IAplicacaoFinanceiraRepository, AplicacaoFinanceiraRepository>();
        services.AddScoped<IHistoricoAplicacaoFinanceiraRepository, HistoricoAplicacaoFinanceiraRepository>();
        services.AddScoped<IControleMensalRepository, ControleMensalRepository>();
        services.AddScoped<IControleMensalCreditoRepository, ControleMensalCreditoRepository>();
        services.AddScoped<IControleMensalDebitoRepository, ControleMensalDebitoRepository>();
        return services;
    }
}

using Kazue.Domain.Interfaces.Connection;
using Kazue.Infrastructure.Connection;
using Kazue.Infrastructure.Parameters.Barber;
using Kazue.Infrastructure.Repository.Barber;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kazue.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddRepositories(services);
        AddParameters(services);
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IBarberRepository, BarberRepository>();

    }

    private static void AddParameters(IServiceCollection services)
    {
        services.AddScoped<IKazueConnection, KazueConnection>();
        services.AddScoped<IBarberParameter, BarberParameters>();
    }
}

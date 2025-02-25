using Kazue.Application.UseCases.Barber.Create;
using Kazue.Application.UseCases.Barber.GetById;
using Microsoft.Extensions.DependencyInjection;

namespace Kazue.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddUseCases(services);
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<ICreateBarberUseCase, CreateBarberUseCase>();
        services.AddScoped<IGetBarberByIdUseCase, GetBarberByIdUseCase>();
    }

}

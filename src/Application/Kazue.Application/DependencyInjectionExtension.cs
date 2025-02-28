using Kazue.Application.UseCases.User.Create;
using Kazue.Application.UseCases.User.GetById;
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
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
    }

}

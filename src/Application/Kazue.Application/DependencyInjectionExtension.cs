using Kazue.Application.UseCases.Category.Create;
using Kazue.Application.UseCases.Category.Delete;
using Kazue.Application.UseCases.Category.Get;
using Kazue.Application.UseCases.Category.GetById;
using Kazue.Application.UseCases.Category.Update;
using Kazue.Application.UseCases.Login.DoLogin;
using Kazue.Application.UseCases.Queue.Create;
using Kazue.Application.UseCases.Queue.Delete;
using Kazue.Application.UseCases.Queue.Get;
using Kazue.Application.UseCases.Queue.GetById;
using Kazue.Application.UseCases.Queue.Update;
using Kazue.Application.UseCases.Service.Create;
using Kazue.Application.UseCases.Service.Delete;
using Kazue.Application.UseCases.Service.Get;
using Kazue.Application.UseCases.Service.GetById;
using Kazue.Application.UseCases.Service.Update;
using Kazue.Application.UseCases.Status.Create;
using Kazue.Application.UseCases.Status.Delete;
using Kazue.Application.UseCases.Status.Get;
using Kazue.Application.UseCases.Status.GetById;
using Kazue.Application.UseCases.Status.Update;
using Kazue.Application.UseCases.User.ChangePassword;
using Kazue.Application.UseCases.User.Create;
using Kazue.Application.UseCases.User.Delete;
using Kazue.Application.UseCases.User.Get;
using Kazue.Application.UseCases.User.GetById;
using Kazue.Application.UseCases.User.Update;
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
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();

        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<IChangePasswordUserUseCase, ChangePasswordUserUseCase>();
        services.AddScoped<IDeleteUserUseCase, DeleteUserUseCase>();
        services.AddScoped<IGetUserUseCase, GetUserUseCase>();
        services.AddScoped<IGetUserByIdUseCase, GetUserByIdUseCase>();
        services.AddScoped<IUpdateUserUseCase, UpdateUserUseCase>();

        services.AddScoped<ICreateStatusUseCase, CreateStatusUseCase>();
        services.AddScoped<IDeleteStatusUseCase, DeleteStatusUseCase>();
        services.AddScoped<IGetStatusUseCase, GetStatusUseCase>();
        services.AddScoped<IGetStatusByIdUseCase, GetStatusByIdUseCase>();
        services.AddScoped<IUpdateStatusUseCase, UpdateStatusUseCase>();

        services.AddScoped<ICreateServiceUseCase, CreateServiceUseCase>();
        services.AddScoped<IDeleteServiceUseCase, DeleteServiceUseCase>();
        services.AddScoped<IGetServiceUseCase, GetServiceUseCase>();
        services.AddScoped<IGetServiceByIdUseCase, GetServiceByIdUseCase>();
        services.AddScoped<IUpdateServiceUseCase, UpdateServiceUseCase>();

        services.AddScoped<ICreateQueueUseCase, CreateQueueUseCase>();
        services.AddScoped<IDeleteQueueUseCase, DeleteQueueUseCase>();
        services.AddScoped<IGetQueueUseCase, GetQueueUseCase>();
        services.AddScoped<IGetByIdQueueUseCase, GetByIdQueueUseCase>();
        services.AddScoped<IUpdateQueueUseCase, UpdateQueueUseCase>();

        services.AddScoped<ICreateCategoryUseCase, CreateCategoryUseCase>();
        services.AddScoped<IDeleteCategoryUseCase, DeleteCategoryUseCase>();
        services.AddScoped<IGetCategoryUseCase, GetCategoryUseCase>();
        services.AddScoped<IGetCategoryByIdUseCase, GetCategoryByIdUseCase>();
        services.AddScoped<IUpdateCategoryUseCase, UpdateCategoryUseCase>();
    }
}

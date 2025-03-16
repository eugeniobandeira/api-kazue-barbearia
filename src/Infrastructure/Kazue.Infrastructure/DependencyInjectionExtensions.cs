using Kazue.Domain.Interfaces.Infrastructure.Connection;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Category;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Queue;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Service;
using Kazue.Domain.Interfaces.Infrastructure.Repository.Status;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Cryptography;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Interfaces.Service.LoggedUser;
using Kazue.Infrastructure.Connection;
using Kazue.Infrastructure.Parameters.Category;
using Kazue.Infrastructure.Parameters.Queue;
using Kazue.Infrastructure.Parameters.Service;
using Kazue.Infrastructure.Parameters.Status;
using Kazue.Infrastructure.Parameters.User;
using Kazue.Infrastructure.Repository.Category;
using Kazue.Infrastructure.Repository.Queue;
using Kazue.Infrastructure.Repository.Service;
using Kazue.Infrastructure.Repository.Status;
using Kazue.Infrastructure.Repository.User;
using Kazue.Infrastructure.Security.Cryptography;
using Kazue.Infrastructure.Security.Token;
using Kazue.Infrastructure.Service.LoggedUser;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Kazue.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        AddSecurityServices(services);
        AddToken(services, configuration);
        AddRepositories(services);
        AddParameters(services);
    }
    
    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpiresMinutes");

        var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

        services.AddScoped<IJwtTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
    }

    private static void AddSecurityServices(IServiceCollection services)
    {
        services.AddScoped<IPasswordEncrypter, PasswordEncrypter>();
        services.AddScoped<ILoggedUser, LoggedUser>();
    }

    private static void AddParameters(IServiceCollection services)
    {
        services.AddScoped<IKazueConnection, KazueConnection>();
        services.AddScoped<IUserParameter, UserParameters>();
        services.AddScoped<IStatusParameter, StatusParameter>();
        services.AddScoped<IServiceParameter, ServiceParameter>();
        services.AddScoped<IQueueParameter, QueueParameter>();
        services.AddScoped<ICategoryParameter, CategoryParameter>();
    }

    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<ICreateUserRepository, UserRepository>();
        services.AddScoped<IReadUserRepository, UserRepository>();
        services.AddScoped<IUpdateUserRepository, UserRepository>();
        services.AddScoped<IDeleteUserRepository, UserRepository>();

        services.AddScoped<ICreateStatusRepository, StatusRepository>();
        services.AddScoped<IReadStatusRepository, StatusRepository>();
        services.AddScoped<IDeleteStatusRepository, StatusRepository>();
        services.AddScoped<IUpdateStatusRepository, StatusRepository>();

        services.AddScoped<ICreateServiceRepository, ServiceRepository>();
        services.AddScoped<IDeleteServiceRepository, ServiceRepository>();
        services.AddScoped<IReadServiceRepository, ServiceRepository>();
        services.AddScoped<IUpdateServiceRepository, ServiceRepository>();

        services.AddScoped<ICreateQueueRepository, QueueRepository>();
        services.AddScoped<IDeleteQueueRepository, QueueRepository>();
        services.AddScoped<IReadQueueRepository, QueueRepository>();
        services.AddScoped<IUpdateQueueRepository, QueueRepository>();

        services.AddScoped<ICreateCategoryRepository, CategoryRepository>();
        services.AddScoped<IDeleteCategoryRepository, CategoryRepository>();
        services.AddScoped<IReadCategoryRepository, CategoryRepository>();
        services.AddScoped<IUpdateCategoryRepository, CategoryRepository>();
    }
}

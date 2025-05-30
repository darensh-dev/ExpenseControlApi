using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Application.Services;
using ExpenseControlApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseControlApi.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Servicios
        services.AddScoped<UserService>();
        services.AddScoped<ExpenseService>();
        builder.Services.AddScoped<TokenService>();
        // ...

        // Repositorios
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        // ...

        return services;
    }
}

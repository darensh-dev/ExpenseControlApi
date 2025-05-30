// using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Services.Auth;
using ExpenseControlApi.Application.Services;
using ExpenseControlApi.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ExpenseControlApi.Application.Interfaces;


namespace ExpenseControlApi.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Servicios
        services.AddScoped<UserService>();
        services.AddScoped<TokenService>();
        // services.AddScoped<ExpenseService>();
        // ...

        // Repositorios
        services.AddScoped<IUserRepository, UserRepository>();
        // services.AddScoped<IExpenseRepository, ExpenseRepository>();
        // ...

        return services;
    }
}

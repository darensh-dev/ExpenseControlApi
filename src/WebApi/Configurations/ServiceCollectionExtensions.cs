using ExpenseControlApi.Services.Auth;
using ExpenseControlApi.Application.Services;
using ExpenseControlApi.Infrastructure.Repositories;
using ExpenseControlApi.Application.Interfaces;
using Microsoft.Extensions.DependencyInjection;


namespace ExpenseControlApi.Application.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        // Servicios
        services.AddScoped<UserService>();
        services.AddScoped<TokenService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IDocumentTypeService, DocumentTypeService>();
        services.AddScoped<IExpenseTypeService, ExpenseTypeService>();
        services.AddScoped<IFundTypeService, FundTypeService>();

        // Repositorios
        services.AddScoped<ILoginLogRepository, LoginLogRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDocumentTypeRepository, DocumentTypeRepository>();
        services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
        services.AddScoped<IFundTypeRepository, FundTypeRepository>();

        return services;
    }
}

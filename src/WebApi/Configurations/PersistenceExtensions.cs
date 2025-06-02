using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpenseControlApi.Infrastructure.DependencyInjection;

public static class PersistenceExtensions
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration config)
    {
        string? connString = config.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(connString))
            throw new InvalidOperationException("Connection string 'DefaultConnection' is not configured.");

        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(connString));

        return services;
    }
}

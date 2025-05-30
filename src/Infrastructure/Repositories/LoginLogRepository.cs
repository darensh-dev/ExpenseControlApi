// Infrastructure/Repositories/LoginLogRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class LoginLogRepository : ILoginLogRepository
{
    private readonly AppDbContext _context;

    public LoginLogRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(LoginLog log)
    {
        _context.LoginLog.Add(log);
        await _context.SaveChangesAsync();
    }
}

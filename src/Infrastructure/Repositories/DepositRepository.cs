// Archivo: src/Infrastructure/Repositories/DepositRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class DepositRepository : IDepositRepository
{
    private readonly AppDbContext _context;

    public DepositRepository(AppDbContext context)
    {
        _context = context;
    }


    public async Task<Deposit?> GetByIdAsync(long id, long userId)
    {
        return await _context.Deposit
            .Where(d => d.Id == id && d.DeletedAt == null && d.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Deposit>> GetByDateAsync(long userId, long year, long month)
    {
        return await _context.Deposit
            .Where(d =>
                d.DeletedAt == null &&
                d.UserId == userId &&
                d.Date.Year == year &&
                d.Date.Month == month)
            .ToListAsync();
    }

    public async Task AddAsync(Deposit entity)
    {
        _context.Deposit.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(long id, long userId)
    {
        var deposit = await _context.Deposit
            .Where(d => d.Id == id && d.UserId == userId && d.DeletedAt == null)
            .FirstOrDefaultAsync();

        if (deposit != null)
        {
            deposit.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();
        }
    }
}

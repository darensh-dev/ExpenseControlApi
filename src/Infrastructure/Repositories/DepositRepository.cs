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
            .Include(e => e.MonetaryFund)
            .Where(e => e.Id == id && e.DeletedAt == null && e.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Deposit>> GetByDateAsync(long userId, long year, long month)
    {
        return await _context.Deposit
            .Include(e => e.MonetaryFund)
            .Where(e =>
                e.DeletedAt == null &&
                e.UserId == userId &&
                e.Date.Year == year &&
                e.Date.Month == month)
            .ToListAsync();
    }

    public async Task AddAsync(Deposit entity)
    {
        _context.Deposit.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Deposit entity)
    {
        _context.Deposit.Update(entity);
        await _context.SaveChangesAsync();
    }
}

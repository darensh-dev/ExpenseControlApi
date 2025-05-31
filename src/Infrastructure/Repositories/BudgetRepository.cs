// Archivo: src/Infrastructure/Repositories/BudgetRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class BudgetRepository : IBudgetRepository
{
    private readonly AppDbContext _context;

    public BudgetRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Budget entity)
    {
        _context.Budget.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Budget?> GetByIdAsync(long id, long userId)
    {
        return await _context.Budget
            .Where(d => d.Id == id && d.DeletedAt == null && d.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Budget>> GetAllAsync(long userId)
    {
        return await _context.Budget
            .Where(dt => dt.DeletedAt == null && dt.UserId == userId)
            .ToListAsync();
    }

    public async Task<Budget?> GetByTypeAndMonthAsync(int expenseTypeId, long userId, DateOnly month)
    {
        return await _context.Budget
            .Where(b => b.ExpenseTypeId == expenseTypeId &&
                        b.Month.Year == month.Year &&
                        b.Month.Month == month.Month &&
                        b.DeletedAt == null &&
                        b.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task UpdateAsync(Budget entity)
    {
        _context.Budget.Update(entity);
        await _context.SaveChangesAsync();
    }
}
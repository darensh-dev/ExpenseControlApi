// Archivo: src/Infrastructure/Repositories/BudgetRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ExpenseControlApi.Application.DTOs;

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
            .Include(b => b.ExpenseType)
            .Where(
                d => d.Id == id &&
                d.DeletedAt == null &&
                d.UserId == userId)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Budget>> GetAllAsync(long userId)
    {
        return await _context.Budget
            .Include(b => b.ExpenseType)
            .Where(dt => dt.DeletedAt == null && dt.UserId == userId)
            .ToListAsync();
    }

    public async Task<BudgetSummaryDto> GetByTypeAndMonthAsync(int expenseTypeId, long userId, DateOnly month)
    {
        var total = await _context.Budget
            .Where(
                b => b.ExpenseTypeId == expenseTypeId &&
                     b.Month.Year == month.Year &&
                     b.Month.Month == month.Month &&
                     b.DeletedAt == null &&
                     b.UserId == userId)
            .SumAsync(b => (decimal?)b.Amount) ?? 0;

        var expenseTypeName = await _context.ExpenseType
            .Where(e => e.Id == expenseTypeId)
            .Select(e => e.Name)
            .FirstOrDefaultAsync();

        return new BudgetSummaryDto
        {
            Id = expenseTypeId,
            ExpenseTypeName = expenseTypeName!,
            TotalBudgeted = total
        };
    }

    public async Task UpdateAsync(Budget entity)
    {
        _context.Budget.Update(entity);
        await _context.SaveChangesAsync();
    }
}
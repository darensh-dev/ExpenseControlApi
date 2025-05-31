// Archivo: src/Infrastructure/Repositories/ExpenseRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class ExpenseRepository : IExpenseRepository
{
    private readonly AppDbContext _context;

    public ExpenseRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ExpenseHeader?> GetByIdAsync(long id, long userId)
    {
        return await _context.ExpenseHeader
            .Include(e => e.ExpenseDetails).ThenInclude(d => d.ExpenseType)
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == userId && e.DeletedAt == null);
    }

    public async Task<List<ExpenseHeader>> GetByDateAsync(long userId, int year, int month)
    {
        return await _context.ExpenseHeader
            .Include(e => e.ExpenseDetails).ThenInclude(d => d.ExpenseType)
            .Where(e => e.UserId == userId &&
                        e.Date.Year == year &&
                        e.Date.Month == month &&
                        e.DeletedAt == null)
            .ToListAsync();
    }

    public async Task AddAsync(ExpenseHeader expense, List<ExpenseDetail> details)
    {
        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            _context.ExpenseHeader.Add(expense);
            await _context.SaveChangesAsync();

            foreach (var detail in details)
            {
                detail.ExpenseHeaderId = expense.Id;
                _context.ExpenseDetail.Add(detail);
            }

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    public async Task<decimal> GetTotalSpentByTypeInMonthAsync(int expenseTypeId, long userId, DateOnly month)
    {
        return await _context.ExpenseDetail
            .Where(d => d.ExpenseTypeId == expenseTypeId &
                        d.ExpenseHeader.UserId == userId &&
                        d.ExpenseHeader.Date.Year == month.Year &&
                        d.ExpenseHeader.Date.Month == month.Month &&
                        d.ExpenseHeader.DeletedAt == null)
            .SumAsync(d => (decimal?)d.Amount) ?? 0;
    }
}

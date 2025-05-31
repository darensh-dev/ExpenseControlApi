// src/Infrastructure/Repositories/ExpenseTypeRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class ExpenseTypeRepository : IExpenseTypeRepository
{
    private readonly AppDbContext _context;

    public ExpenseTypeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ExpenseType?> GetByIdAsync(int id, long userId)
    {
        return await _context.ExpenseType
            .Where(
                dt => dt.DeletedAt == null &&
                dt.Id == id &&
                (dt.CreatedByUserId == null || dt.CreatedByUserId == userId)
            )
            .FirstOrDefaultAsync();
    }

    public async Task<List<ExpenseType>> GetAllAsync(long userId)
    {
        return await _context.ExpenseType
            .Where(
                dt => dt.DeletedAt == null &&
                (
                    dt.CreatedByUserId == null
                    || dt.CreatedByUserId == userId
                )
            )
            .ToListAsync();
    }

    public async Task AddAsync(ExpenseType entity)
    {
        _context.ExpenseType.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<string> GenerateNextCodeAsync(long userId)
    {
        var last = await _context.ExpenseType
            .Where(e => e.CreatedByUserId == userId)
            .OrderByDescending(e => e.Id)
            .FirstOrDefaultAsync();

        int nextNumber = 1;

        if (last != null && !string.IsNullOrEmpty(last.Code))
        {
            var parts = last.Code.Split('-');
            if (parts.Length == 2 && int.TryParse(parts[1], out int lastNumber))
            {
                nextNumber = lastNumber + 1;
            }
        }

        return $"ET-{nextNumber:D4}";
    }

    public async Task<Dictionary<int, ExpenseType>> GetByIdsAsync(IEnumerable<int> ids)
    {
        return await _context.ExpenseType
            .Where(et => ids.Contains(et.Id))
            .ToDictionaryAsync(et => et.Id);
    }

}

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

    public async Task<List<ExpenseType>> GetAllAsync(long userId)
    {
        return await _context.ExpenseType
            .Where(dt => dt.DeletedAt == null &&
                        (dt.CreatedByUserId == null || dt.CreatedByUserId == userId))
            .ToListAsync();
    }

    public async Task AddAsync(ExpenseType entity)
    {
        _context.ExpenseType.Add(entity);
        await _context.SaveChangesAsync();
    }
}

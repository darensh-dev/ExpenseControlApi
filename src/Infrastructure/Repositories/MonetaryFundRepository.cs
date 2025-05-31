// Archivo: src/Infrastructure/Repositories/MonetaryFundRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class MonetaryFundRepository : IMonetaryFundRepository
{
    private readonly AppDbContext _context;

    public MonetaryFundRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<MonetaryFund?> GetByIdAsync(long id, long userId)
    {
        return await _context.MonetaryFund.Include(e => e.FundType)
            .FirstOrDefaultAsync(
                mf => mf.Id == id &&
                mf.UserId == userId &&
                mf.DeletedAt == null
            );
    }

    public async Task<List<MonetaryFund>> GetAllAsync(long userId)
    {
        return await _context.MonetaryFund.Include(e => e.FundType)
            .Where(
                mf => mf.DeletedAt == null
                && mf.UserId == userId
                && mf.DeletedAt == null
            )
            .ToListAsync();
    }

    public async Task AddAsync(MonetaryFund entity)
    {
        _context.MonetaryFund.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(MonetaryFund entity)
    {
        _context.MonetaryFund.Update(entity);
        await _context.SaveChangesAsync();
    }
}

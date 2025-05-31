// Archivo: src/Infrastructure/Repositories/FundTypeRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class FundTypeRepository : IFundTypeRepository
{
    private readonly AppDbContext _context;

    public FundTypeRepository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<List<FundType>> GetAllAsync(long userId)
    {
        return await _context.FundType
            .Where(dt => dt.DeletedAt == null &&
                        (dt.CreatedByUserId == null || dt.CreatedByUserId == userId))
            .ToListAsync();
    }

    public async Task AddAsync(FundType entity)
    {
        _context.FundType.Add(entity);
        await _context.SaveChangesAsync();
    }
}

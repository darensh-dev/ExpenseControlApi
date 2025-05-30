// Archivo: src/Infrastructure/Repositories/BudgetRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class BudgetRepository // : IBudgetRepository
{
    private readonly AppDbContext _context;

    public BudgetRepository(AppDbContext context)
    {
        _context = context;
    }

    // public async Task AddAsync(Budget entity)
    // {
    //     _context.Budgets.Add(entity);
    //     await _context.SaveChangesAsync();
    // }

    // public async Task<Budget?> GetByIdAsync(long id)
    // {
    //     return await _context.Budgets.FindAsync(id);
    // }

    // public async Task<List<Budget>> GetAllAsync()
    // {
    //     return await _context.Budgets.ToListAsync();
    // }

    // public async Task UpdateAsync(Budget entity)
    // {
    //     _context.Budgets.Update(entity);
    //     await _context.SaveChangesAsync();
    // }

    // public async Task DeleteAsync(long id)
    // {
    //     var entity = await _context.Budgets.FindAsync(id);
    //     if (entity != null)
    //     {
    //         _context.Budgets.Remove(entity);
    //         await _context.SaveChangesAsync();
    //     }
    // }
}
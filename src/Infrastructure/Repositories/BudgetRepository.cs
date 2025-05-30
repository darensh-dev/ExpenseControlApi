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

    // Métodos CRUD aquí (implementación pendiente)
}

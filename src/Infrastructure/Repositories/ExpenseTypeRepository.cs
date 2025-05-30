// Archivo: src/Infrastructure/Repositories/ExpenseTypeRepository.cs
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

    // Métodos CRUD aquí (implementación pendiente)
}

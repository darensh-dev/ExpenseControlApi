// Archivo: src/Infrastructure/Repositories/ExpenseDetailRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class ExpenseDetailRepository // : IExpenseDetailRepository
{
    private readonly AppDbContext _context;

    public ExpenseDetailRepository(AppDbContext context)
    {
        _context = context;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

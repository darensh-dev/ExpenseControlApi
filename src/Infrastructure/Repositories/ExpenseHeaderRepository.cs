// Archivo: src/Infrastructure/Repositories/ExpenseHeaderRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class ExpenseHeaderRepository // : IExpenseHeaderRepository
{
    private readonly AppDbContext _context;

    public ExpenseHeaderRepository(AppDbContext context)
    {
        _context = context;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

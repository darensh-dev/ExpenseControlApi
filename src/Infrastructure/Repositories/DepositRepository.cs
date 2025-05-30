// Archivo: src/Infrastructure/Repositories/DepositRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class DepositRepository // : IDepositRepository
{
    private readonly AppDbContext _context;

    public DepositRepository(AppDbContext context)
    {
        _context = context;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

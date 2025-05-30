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

    // Métodos CRUD aquí (implementación pendiente)
}

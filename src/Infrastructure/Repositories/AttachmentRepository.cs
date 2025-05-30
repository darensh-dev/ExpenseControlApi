// Archivo: src/Infrastructure/Repositories/AttachmentRepository.cs
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ExpenseControlApi.Infrastructure.Repositories;

public class AttachmentRepository // : IAttachmentRepository
{
    private readonly AppDbContext _context;

    public AttachmentRepository(AppDbContext context)
    {
        _context = context;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

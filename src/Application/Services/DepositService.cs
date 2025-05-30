// Archivo: src/Application/Services/DepositService.cs
// Requiere: DepositDto, DepositCreateDto, DepositUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
// using ExpenseControlApi.Application.Interfaces.Repositories;
// using ExpenseControlApi.Application.Interfaces.Services
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class DepositService // : IDepositService
{
    private readonly IDepositRepository _repository;

    public DepositService(IDepositRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

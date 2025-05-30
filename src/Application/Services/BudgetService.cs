// Archivo: src/Application/Services/BudgetService.cs
// Requiere: BudgetDto, BudgetCreateDto, BudgetUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Application.Interfaces.Services;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _repository;

    public BudgetService(IBudgetRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

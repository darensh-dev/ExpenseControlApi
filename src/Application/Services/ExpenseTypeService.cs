// Archivo: src/Application/Services/ExpenseTypeService.cs
// Requiere: ExpenseTypeDto, ExpenseTypeCreateDto, ExpenseTypeUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class ExpenseTypeService : IExpenseTypeService
{
    private readonly IExpenseTypeRepository _repository;

    public ExpenseTypeService(IExpenseTypeRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

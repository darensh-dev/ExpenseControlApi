// Archivo: src/Application/Services/ExpenseService.cs
// Requiere: ExpenseHeaderDto, ExpenseHeaderCreateDto, ExpenseHeaderUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
// using ExpenseControlApi.Application.Interfaces.Repositories;
// using ExpenseControlApi.Application.Interfaces.Services
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class ExpenseService // : IExpenseService
{
    private readonly IExpenseHeaderRepository _repository;

    public ExpenseService(IExpenseHeaderRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

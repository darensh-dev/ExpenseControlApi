// Archivo: src/Application/Services/ExpenseHeaderService.cs
// Requiere: ExpenseHeaderDto, ExpenseHeaderCreateDto, ExpenseHeaderUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
// using ExpenseControlApi.Application.Interfaces.Repositories;
// using ExpenseControlApi.Application.Interfaces.Services
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class ExpenseHeaderService // : IExpenseHeaderService
{
    private readonly IExpenseHeaderRepository _repository;

    public ExpenseHeaderService(IExpenseHeaderRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

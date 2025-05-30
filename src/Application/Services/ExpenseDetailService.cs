// Archivo: src/Application/Services/ExpenseDetailService.cs
// Requiere: ExpenseDetailDto, ExpenseDetailCreateDto, ExpenseDetailUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Application.Interfaces.Services;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class ExpenseDetailService : IExpenseDetailService
{
    private readonly IExpenseDetailRepository _repository;

    public ExpenseDetailService(IExpenseDetailRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

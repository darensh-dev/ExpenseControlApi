// Archivo: src/Application/Services/MonetaryFundService.cs
// Requiere: MonetaryFundDto, MonetaryFundCreateDto, MonetaryFundUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
// using ExpenseControlApi.Application.Interfaces.Repositories;
// using ExpenseControlApi.Application.Interfaces.Services
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class MonetaryFundService // : IMonetaryFundService
{
    private readonly IMonetaryFundRepository _repository;

    public MonetaryFundService(IMonetaryFundRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

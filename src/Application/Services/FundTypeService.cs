// Archivo: src/Application/Services/FundTypeService.cs
// Requiere: FundTypeDto, FundTypeCreateDto, FundTypeUpdateDto en Application/DTOs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces.Repositories;
using ExpenseControlApi.Application.Interfaces.Services;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class FundTypeService : IFundTypeService
{
    private readonly IFundTypeRepository _repository;

    public FundTypeService(IFundTypeRepository repository)
    {
        _repository = repository;
    }

    // Métodos CRUD aquí (implementación pendiente)
}

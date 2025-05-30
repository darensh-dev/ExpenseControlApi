// src/Application/Services/ExpenseTypeService.cs
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

    public async Task<List<ExpenseTypeDto>> GetAllAsync(long userId)
    {
        var ExpenseType = await _repository.GetAllAsync(userId);
        return ExpenseType.Select(exp => new ExpenseTypeDto
        {
            Id = exp.Id,
            Name = exp.Name,
            Description = exp.Description,
            Code = exp.Code!,
        }).ToList();
    }

    public async Task AddAsync(ExpenseTypeCreateServiceDto dto)
    {
        var expenseType = new ExpenseType
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedByUserId = dto.CreatedByUserId,
        };

        await _repository.AddAsync(expenseType);

    }

}

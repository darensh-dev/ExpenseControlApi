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

    public async Task<ExpenseTypeDto> AddAsync(ExpenseTypeCreateServiceDto dto)
    {
        var code = await _repository.GenerateNextCodeAsync(dto.CreatedByUserId);
        var entity = new ExpenseType
        {
            Name = dto.Name,
            Description = dto.Description,
            CreatedByUserId = dto.CreatedByUserId,
            Code = code
        };

        await _repository.AddAsync(entity);

        return new ExpenseTypeDto
        {
            Id = entity.Id,
            Code = entity.Code,
            Name = entity.Name,
            Description = entity.Description
        };
    }

}

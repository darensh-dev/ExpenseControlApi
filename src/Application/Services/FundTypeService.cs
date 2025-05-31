// src/Application/Services/FundTypeService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class FundTypeService : IFundTypeService
{
    private readonly IFundTypeRepository _repository;

    public FundTypeService(IFundTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FundTypeDto>> GetAllAsync(long userId)
    {
        var ExpenseType = await _repository.GetAllAsync(userId);
        return ExpenseType.Select(exp => new FundTypeDto
        {
            Id = exp.Id,
            Name = exp.Name,
        }).ToList();
    }

    public async Task<FundTypeDto> AddAsync(FundTypeCreateServiceDto dto)
    {
        var entity = new FundType
        {
            Name = dto.Name,
            CreatedByUserId = dto.CreatedByUserId,
        };

        await _repository.AddAsync(entity);

        return new FundTypeDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }

}

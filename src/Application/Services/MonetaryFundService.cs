// src/Application/Services/MonetaryFundService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class MonetaryFundService : IMonetaryFundService
{
    private readonly IMonetaryFundRepository _repository;

    public MonetaryFundService(IMonetaryFundRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MonetaryFundDto>> GetAllAsync(long userId)
    {
        var MonetaryFund = await _repository.GetAllAsync(userId);
        return MonetaryFund.Select(exp => new MonetaryFundDto
        {
            Id = exp.Id,
            Name = exp.Name,
            InitialBalance = exp.InitialBalance,
            CreatedAt = exp.CreatedAt,
            UpdatedAt = exp.UpdatedAt,
            DeletedAt = exp.DeletedAt,
        }).ToList();
    }

    public async Task<MonetaryFundDto> AddAsync(long userId, MonetaryFundCreateDto dto)
    {
        var entity = new MonetaryFund
        {
            Name = dto.Name,
            InitialBalance = dto.InitialBalance,
            UserId = userId,
        };

        await _repository.AddAsync(entity);

        return new MonetaryFundDto
        {
            Id = entity.Id,
            Name = entity.Name,
            InitialBalance = entity.InitialBalance,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
        };
    }

    public async Task<MonetaryFundDto> UpdateAsync(long userId, MonetaryFundUpdateDto dto)
    {
        var existing = await _repository.GetByIdAsync(dto.Id);
        if (existing != null)
        {
            throw new Exception("Monetary Fund already taken");
        }
        var entity = new MonetaryFund
        {
            Id = dto.Id,
            Name = dto.Name,
            InitialBalance = dto.InitialBalance,
        };

        await _repository.UpdateAsync(entity);

        return new MonetaryFundDto
        {
            Id = entity.Id,
            Name = entity.Name,
            InitialBalance = entity.InitialBalance,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
        };
    }
}

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
        return MonetaryFund.Select(mf => new MonetaryFundDto
        {
            Id = mf.Id,
            Name = mf.Name,
            FundTypeId = mf.FundTypeId,
            InitialBalance = mf.InitialBalance,
            CreatedAt = mf.CreatedAt,
            UpdatedAt = mf.UpdatedAt,
            DeletedAt = mf.DeletedAt,
        }).ToList();
    }

    public async Task<MonetaryFundDto> AddAsync(long userId, MonetaryFundCreateDto dto)
    {
        var entity = new MonetaryFund
        {
            Name = dto.Name,
            InitialBalance = dto.InitialBalance,
            FundTypeId = dto.FundTypeId,
            UserId = userId,
        };

        await _repository.AddAsync(entity);

        return new MonetaryFundDto
        {
            Id = entity.Id,
            Name = entity.Name,
            FundTypeId = entity.FundTypeId,
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
            FundTypeId = entity.FundTypeId,
            InitialBalance = entity.InitialBalance,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
        };
    }
}

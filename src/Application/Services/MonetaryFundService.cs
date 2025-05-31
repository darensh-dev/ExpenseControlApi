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

    public async Task<MonetaryFundDto?> GetByIdAsync(long id, long userId)
    {
        var monetaryFund = await _repository.GetByIdAsync(id, userId);

        if (monetaryFund == null)
            return null;

        return new MonetaryFundDto
        {
            Id = monetaryFund.Id,
            Name = monetaryFund.Name,
            FundTypeId = monetaryFund.FundTypeId,
            InitialBalance = monetaryFund.InitialBalance,
            CreatedAt = monetaryFund.CreatedAt,
            UpdatedAt = monetaryFund.UpdatedAt,
            DeletedAt = monetaryFund.DeletedAt,
        };
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
        var entity = await _repository.GetByIdAsync(dto.Id, userId);
        if (entity == null)
        {
            throw new Exception("Monetary fund not found or access denied.");
        }

        if (dto.Name is not null) entity.Name = dto.Name;
        if (dto.FundTypeId.HasValue) entity.FundTypeId = dto.FundTypeId.Value;
        if (dto.InitialBalance.HasValue) entity.InitialBalance = dto.InitialBalance.Value;

        entity.UpdatedAt = DateTime.UtcNow;
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

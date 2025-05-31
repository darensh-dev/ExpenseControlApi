// src/Application/Services/MonetaryFundService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class MonetaryFundService : IMonetaryFundService
{
    private readonly IMonetaryFundRepository _repository;
    private readonly IFundTypeRepository _fundTypeRepository;

    public MonetaryFundService(IMonetaryFundRepository repository, IFundTypeRepository fundTypeRepository)
    {
        _repository = repository;
        _fundTypeRepository = fundTypeRepository;

    }

    public async Task<List<MonetaryFundDto>> GetAllAsync(long userId)
    {
        var entity = await _repository.GetAllAsync(userId);
        return entity.Select(mf => new MonetaryFundDto
        {
            Id = mf.Id,
            Name = mf.Name,
            InitialBalance = mf.InitialBalance,
            CreatedAt = mf.CreatedAt,
            UpdatedAt = mf.UpdatedAt,
            DeletedAt = mf.DeletedAt,
            FundType = new FundTypeDto
            {
                Id = mf.FundType.Id,
                Name = mf.FundType.Name,
            }
        }).ToList();
    }

    public async Task<MonetaryFundDto?> GetByIdAsync(long id, long userId)
    {
        var entity = await _repository.GetByIdAsync(id, userId);

        if (entity == null) return null;

        return new MonetaryFundDto
        {
            Id = entity.Id,
            Name = entity.Name,
            InitialBalance = entity.InitialBalance,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            FundType = new FundTypeDto
            {
                Id = entity.FundType.Id,
                Name = entity.FundType.Name,
            }
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
        var fundType = await _fundTypeRepository.GetByIdAsync(dto.FundTypeId, userId);
        if (fundType is null) throw new Exception("Fund type not found");

        return new MonetaryFundDto
        {
            Id = entity.Id,
            Name = entity.Name,
            InitialBalance = entity.InitialBalance,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            FundType = new FundTypeDto
            {
                Id = fundType.Id,
                Name = fundType.Name,
            }
        };
    }

    public async Task<MonetaryFundDto> UpdateAsync(long userId, MonetaryFundUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id, userId);
        if (entity == null)
        {
            throw new Exception("Monetary fund not found or access denied.");
        }

        if (dto.Name is null && !dto.InitialBalance.HasValue && !dto.FundTypeId.HasValue)
        {
            throw new Exception("Needs to update at least one value");
        }

        if (dto.Name is not null) entity.Name = dto.Name;
        if (dto.InitialBalance.HasValue) entity.InitialBalance = dto.InitialBalance.Value;
        if (dto.FundTypeId.HasValue)
        {
            var fundType = await _fundTypeRepository.GetByIdAsync(dto.FundTypeId.Value, userId);
            if (fundType is null)
            {
                throw new Exception($"FundType with ID {dto.FundTypeId} not found.");
            }
            entity.FundTypeId = dto.FundTypeId.Value;
        }

        entity.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(entity);

        return new MonetaryFundDto
        {
            Id = entity.Id,
            Name = entity.Name,
            InitialBalance = entity.InitialBalance,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            FundType = new FundTypeDto
            {
                Id = entity.FundType.Id,
                Name = entity.FundType.Name,
            }
        };
    }
}

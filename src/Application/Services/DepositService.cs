// src/Application/Services/DepositService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class DepositService : IDepositService
{
    private readonly IDepositRepository _repository;
    private readonly IMonetaryFundRepository _monetaryFundRepository;
    public DepositService(IDepositRepository repository, IMonetaryFundRepository monetaryFundRepository)
    {
        _repository = repository;
        _monetaryFundRepository = monetaryFundRepository;
    }

    public async Task<List<DepositDto>> GetByDateAsync(long userId, long year, long month)
    {
        var entity = await _repository.GetByDateAsync(userId, year, month);
        return [.. entity.Select(dp => new DepositDto
        {
            Id = dp.Id,
            Date = dp.Date,
            Amount = dp.Amount,
            CreatedAt = dp.CreatedAt,
            UpdatedAt = dp.UpdatedAt,
            DeletedAt = dp.DeletedAt,
            MonetaryFund = new MonetaryFundChildDto
            {
                Id = dp.MonetaryFund.Id,
                Name = dp.MonetaryFund.Name
            },
        })];
    }

    public async Task<DepositDto?> GetByIdAsync(long id, long userId)
    {
        var entity = await _repository.GetByIdAsync(id, userId);

        if (entity == null)
            return null;

        return new DepositDto
        {
            Id = entity.Id,
            Date = entity.Date,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            MonetaryFund = new MonetaryFundChildDto
            {
                Id = entity.MonetaryFund.Id,
                Name = entity.MonetaryFund.Name
            },
        };
    }

    public async Task<DepositDto> AddAsync(long userId, DepositCreateDto dto)
    {
        var entity = new Deposit
        {
            Date = dto.Date,
            Amount = dto.Amount,
            MonetaryFundId = dto.MonetaryFundId,
            UserId = userId,
        };

        await _repository.AddAsync(entity);
        var monetaryFund = await _monetaryFundRepository.GetByIdAsync(dto.MonetaryFundId, userId);
        if (monetaryFund is null) throw new Exception("Monetary Fund type not found");
        return new DepositDto
        {
            Id = entity.Id,
            Date = entity.Date,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            MonetaryFund = new MonetaryFundChildDto
            {
                Id = monetaryFund.MonetaryFund.Id,
                Name = monetaryFund.MonetaryFund.Name
            },
        };
    }
    public async Task DeleteAsync(long id, long userId)
    {
        var entity = await _repository.GetByIdAsync(id, userId);
        if (entity == null)
        {
            throw new Exception("Deposit not found or access denied.");
        }
        entity.DeletedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(entity);
    }
}

// Archivo: src/Application/Services/BudgetService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _repository;

    public BudgetService(IBudgetRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BudgetDto>> GetAllAsync(long userId)
    {
        var budget = await _repository.GetAllAsync(userId);
        return budget.Select(e => new BudgetDto
        {
            Id = e.Id,
            UserId = e.UserId,
            ExpenseTypeId = e.ExpenseTypeId,
            Month = e.Month,
            Amount = e.Amount,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            DeletedAt = e.DeletedAt,
        }).ToList();
    }

    public async Task<BudgetDto?> GetByIdAsync(long id, long userId)
    {
        var entity = await _repository.GetByIdAsync(id, userId);
        if (entity == null) return null;
        return new BudgetDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            ExpenseTypeId = entity.ExpenseTypeId,
            Month = entity.Month,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
        };
    }

    public async Task<BudgetDto> AddAsync(long userId, BudgetCreateDto dto)
    {
        var entity = new Budget
        {
            ExpenseTypeId = dto.ExpenseTypeId,
            Month = dto.Month,
            Amount = dto.Amount,
        };
        await _repository.AddAsync(entity);
        return new BudgetDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            ExpenseTypeId = entity.ExpenseTypeId,
            Month = entity.Month,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
        };
    }

    public async Task<BudgetDto> UpdateAsync(long userId, BudgetUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id, userId);
        if (entity == null) throw new Exception("Budget not found or access denied.");

        entity.UpdatedAt = DateTime.UtcNow;

        await _repository.UpdateAsync(entity);

        return new BudgetDto
        {
            Id = entity.Id,
            UserId = entity.UserId,
            ExpenseTypeId = entity.ExpenseTypeId,
            Month = entity.Month,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
        };
    }

    public async Task DeleteAsync(long id, long userId)
    {
        var entity = await _repository.GetByIdAsync(id, userId);
        if (entity == null)
        {
            throw new Exception("Budget not found or access denied.");
        }
        entity.DeletedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(entity);
    }
}
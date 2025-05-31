// Archivo: src/Application/Services/BudgetService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class BudgetService : IBudgetService
{
    private readonly IBudgetRepository _repository;
    private readonly IExpenseTypeRepository _expenseTypeRepository;

    public BudgetService(IBudgetRepository repository, IExpenseTypeRepository expenseTypeRepository)
    {
        _repository = repository;
        _expenseTypeRepository = expenseTypeRepository;

    }

    public async Task<List<BudgetDto>> GetAllAsync(long userId)
    {
        var budget = await _repository.GetAllAsync(userId);
        return budget.Select(e => new BudgetDto
        {
            Id = e.Id,
            Month = e.Month,
            Amount = e.Amount,
            CreatedAt = e.CreatedAt,
            UpdatedAt = e.UpdatedAt,
            DeletedAt = e.DeletedAt,
            ExpenseType = new ExpenseTypeDto
            {
                Id = e.ExpenseType.Id,
                Name = e.ExpenseType.Name,
                Code = e.ExpenseType.Code,
                Description = e.ExpenseType.Description,
            }
        }).ToList();
    }

    public async Task<BudgetDto?> GetByIdAsync(long id, long userId)
    {
        var entity = await _repository.GetByIdAsync(id, userId);
        if (entity == null) return null;
        return new BudgetDto
        {
            Id = entity.Id,
            Month = entity.Month,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            ExpenseType = new ExpenseTypeDto
            {
                Id = entity.ExpenseType.Id,
                Name = entity.ExpenseType.Name,
                Code = entity.ExpenseType.Code,
                Description = entity.ExpenseType.Description,
            }
        };
    }

    public async Task<BudgetDto> AddAsync(long userId, BudgetCreateDto dto)
    {
        var entity = new Budget
        {
            ExpenseTypeId = dto.ExpenseTypeId,
            Month = dto.Month,
            Amount = dto.Amount,
            UserId = userId,
        };
        await _repository.AddAsync(entity);
        var expenseType = await _expenseTypeRepository.GetByIdAsync(dto.ExpenseTypeId, userId);
        if (expenseType is null) throw new Exception("Expense type not found");

        return new BudgetDto
        {
            Id = entity.Id,
            Month = entity.Month,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            ExpenseType = new ExpenseTypeDto
            {
                Id = expenseType.Id,
                Name = expenseType.Name,
                Code = expenseType.Code,
                Description = expenseType.Description,
            }
        };
    }

    public async Task<BudgetDto> UpdateAsync(long userId, BudgetUpdateDto dto)
    {
        var entity = await _repository.GetByIdAsync(dto.Id, userId);
        if (entity == null) throw new Exception("Budget not found or access denied.");

        if (dto.Month is null && !dto.Amount.HasValue && !dto.ExpenseTypeId.HasValue)
        {
            throw new Exception("Needs to update at least one value");
        }

        if (dto.Month is not null) entity.Month = (DateOnly)dto.Month;
        if (dto.Amount.HasValue) entity.Amount = dto.Amount.Value;

        ExpenseType? updatedExpenseType = null;
        if (dto.ExpenseTypeId.HasValue)
        {
            updatedExpenseType = await _expenseTypeRepository.GetByIdAsync(dto.ExpenseTypeId.Value, userId);
            if (updatedExpenseType is null)
            {
                throw new Exception($"ExpenseType with ID {dto.ExpenseTypeId} not found.");
            }
            entity.ExpenseTypeId = dto.ExpenseTypeId.Value;
        }

        entity.UpdatedAt = DateTime.UtcNow;
        await _repository.UpdateAsync(entity);

        var expenseTypeToUse = updatedExpenseType ?? entity.ExpenseType;
        if (expenseTypeToUse is null) throw new Exception("Expense Type not found");
        return new BudgetDto
        {
            Id = entity.Id,
            Month = entity.Month,
            Amount = entity.Amount,
            CreatedAt = entity.CreatedAt,
            UpdatedAt = entity.UpdatedAt,
            DeletedAt = entity.DeletedAt,
            ExpenseType = new ExpenseTypeDto
            {
                Id = expenseTypeToUse.Id,
                Name = expenseTypeToUse.Name,
                Code = expenseTypeToUse.Code,
                Description = expenseTypeToUse.Description,
            }
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
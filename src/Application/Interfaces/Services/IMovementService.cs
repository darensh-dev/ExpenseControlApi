using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Application.Interfaces;

public interface IMovementService
{
    Task<List<BudgetExecutionDto>> GetBudgetExecutionAsync(long userId, DateRangeFilterDto dto);
    Task<List<MovementDto>> GetAllMovimentAsync(long userId, DateRangeFilterDto dto);
}
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;


namespace ExpenseControlApi.Application.Services;

public class MovementService : IMovementService
{
    private readonly IMovementRepository _repository;
    public MovementService(IMovementRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<BudgetExecutionDto>> GetBudgetExecutionAsync(long userId, DateRangeFilterDto dto)
    {
        var report = await _repository.GetBudgetExecutionAsync(userId, dto);
        return report.Select(u => new BudgetExecutionDto
        {
            ExpenseType = u.ExpenseType,
            BudgetedAmount = u.BudgetedAmount,
            ExecutedAmount = u.ExecutedAmount,

        }).ToList();
    }

    public async Task<List<MovementDto>> GetAllMovimentAsync(long userId, DateRangeFilterDto dto)
    {
        var report = await _repository.GetAllMovimentAsync(userId, dto);
        return report.Select(u => new MovementDto
        {
            MovementType = u.MovementType,
            MovementDate = u.MovementDate,
            FundName = u.FundName,
            DocumentType = u.DocumentType,
            TradeName = u.TradeName,
            ExpenseType = u.ExpenseType,
            Amount = u.Amount,
            Notes = u.Notes,
        }).ToList();
    }
}

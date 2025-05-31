using System.ComponentModel.DataAnnotations;
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Application.Exceptions;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;
    private readonly IBudgetRepository _budgetRepository;

    public ExpenseService(IExpenseRepository repository, IBudgetRepository budgetRepository)
    {
        _repository = repository;
        _budgetRepository = budgetRepository;
    }

    public async Task<ExpenseDto> CreateAsync(long userId, ExpenseCreateDto dto)
    {
        await ValidateBudgetAsync(dto.Details, dto.Date, userId);

        var header = new ExpenseHeader
        {
            UserId = userId,
            MonetaryFundId = dto.MonetaryFundId,
            Date = dto.Date,
            MerchantName = dto.MerchantName,
            DocumentTypeId = dto.DocumentTypeId,
            OtherDocumentTypeText = dto.OtherDocumentTypeText,
            Notes = dto.Notes,
        };

        var details = dto.Details.Select(d => new ExpenseDetail
        {
            ExpenseTypeId = d.ExpenseTypeId,
            Amount = d.Amount,
        }).ToList();

        await _repository.AddAsync(header, details);

        return new ExpenseDto
        {
            Id = header.Id,
            UserId = header.UserId,
            MonetaryFundId = header.MonetaryFundId,
            Date = header.Date,
            MerchantName = header.MerchantName,
            DocumentTypeId = header.DocumentTypeId,
            OtherDocumentTypeText = header.OtherDocumentTypeText,
            Notes = header.Notes,
            CreatedAt = header.CreatedAt,
            UpdatedAt = header.UpdatedAt,
            DeletedAt = header.DeletedAt,
            Details = details.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseHeaderId = d.ExpenseHeaderId,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt,
                DeletedAt = d.DeletedAt
            }).ToList()
        };
    }

    public async Task<ExpenseDto?> GetByIdAsync(long id, long userId)
    {
        var header = await _repository.GetByIdAsync(id, userId);
        if (header == null) return null;

        return new ExpenseDto
        {
            Id = header.Id,
            UserId = header.UserId,
            MonetaryFundId = header.MonetaryFundId,
            Date = header.Date,
            MerchantName = header.MerchantName,
            DocumentTypeId = header.DocumentTypeId,
            OtherDocumentTypeText = header.OtherDocumentTypeText,
            Notes = header.Notes,
            CreatedAt = header.CreatedAt,
            UpdatedAt = header.UpdatedAt,
            DeletedAt = header.DeletedAt,
            Details = header.ExpenseDetails.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseHeaderId = d.ExpenseHeaderId,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt,
                DeletedAt = d.DeletedAt
            }).ToList()
        };
    }

    public async Task<List<ExpenseDto>> GetByDateAsync(long userId, int year, int month)
    {
        var headers = await _repository.GetByDateAsync(userId, year, month);

        return headers.Select(header => new ExpenseDto
        {
            Id = header.Id,
            UserId = header.UserId,
            MonetaryFundId = header.MonetaryFundId,
            Date = header.Date,
            MerchantName = header.MerchantName,
            DocumentTypeId = header.DocumentTypeId,
            OtherDocumentTypeText = header.OtherDocumentTypeText,
            Notes = header.Notes,
            CreatedAt = header.CreatedAt,
            UpdatedAt = header.UpdatedAt,
            DeletedAt = header.DeletedAt,
            Details = header.ExpenseDetails.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseHeaderId = d.ExpenseHeaderId,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt,
                DeletedAt = d.DeletedAt
            }).ToList()
        }).ToList();
    }

    private async Task ValidateBudgetAsync(List<ExpenseDetailCreateDto> details, DateOnly month, long userId)
    {
        foreach (var detail in details)
        {
            var budget = await _budgetRepository.GetByTypeAndMonthAsync(detail.ExpenseTypeId, userId, month);
            if (budget == null) continue;

            var totalSpent = await _repository.GetTotalSpentByTypeInMonthAsync(detail.ExpenseTypeId, userId, month);

            var projected = totalSpent + detail.Amount;
            if (projected > budget.Amount)
            {
                throw new BudgetExceededException(detail.ExpenseTypeId, budget.Amount, projected);
            }
        }
    }
}

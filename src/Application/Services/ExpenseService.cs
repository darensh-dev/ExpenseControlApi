using System.ComponentModel.DataAnnotations;
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;
using ExpenseControlApi.Application.Exceptions;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;
    private readonly IBudgetRepository _budgetRepository;
    private readonly IExpenseTypeRepository _expenseTypeRepository;

    public ExpenseService(IExpenseRepository repository, IBudgetRepository budgetRepository, IExpenseTypeRepository expenseTypeRepository)
    {
        _repository = repository;
        _budgetRepository = budgetRepository;
        _expenseTypeRepository = expenseTypeRepository;

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

        var _header = await _repository.GetByIdAsync(header.Id, userId);
        if (_header == null) throw new Exception("The expense could not be created");

        return new ExpenseDto
        {
            Id = _header.Id,
            UserId = _header.UserId,
            Date = _header.Date,
            MerchantName = _header.MerchantName,
            OtherDocumentTypeText = _header.OtherDocumentTypeText,
            Notes = _header.Notes,
            CreatedAt = _header.CreatedAt,
            UpdatedAt = _header.UpdatedAt,
            DeletedAt = _header.DeletedAt,
            MonetaryFund = new MonetaryFundChildDto
            {
                Id = _header.MonetaryFund.Id,
                Name = _header.MonetaryFund.Name
            },
            DocumentType = new DocumentTypeDto
            {
                Id = _header.DocumentType.Id,
                Name = _header.DocumentType.Name,
            },
            Details = _header.ExpenseDetails.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt,
                DeletedAt = d.DeletedAt,
                ExpenseType = new ExpenseTypeDto
                {
                    Id = d.ExpenseType.Id,
                    Name = d.ExpenseType.Name,
                    Code = d.ExpenseType.Code,
                    Description = d.ExpenseType.Description,
                }
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
            Date = header.Date,
            MerchantName = header.MerchantName,
            OtherDocumentTypeText = header.OtherDocumentTypeText,
            Notes = header.Notes,
            CreatedAt = header.CreatedAt,
            UpdatedAt = header.UpdatedAt,
            DeletedAt = header.DeletedAt,
            MonetaryFund = new MonetaryFundChildDto
            {
                Id = header.MonetaryFund.Id,
                Name = header.MonetaryFund.Name
            },
            DocumentType = new DocumentTypeDto
            {
                Id = header.DocumentType.Id,
                Name = header.DocumentType.Name,
            },
            Details = header.ExpenseDetails.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt,
                DeletedAt = d.DeletedAt,
                ExpenseType = new ExpenseTypeDto
                {
                    Id = d.ExpenseType.Id,
                    Name = d.ExpenseType.Name,
                    Code = d.ExpenseType.Code,
                    Description = d.ExpenseType.Description,
                }
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
            Date = header.Date,
            MerchantName = header.MerchantName,
            OtherDocumentTypeText = header.OtherDocumentTypeText,
            Notes = header.Notes,
            CreatedAt = header.CreatedAt,
            UpdatedAt = header.UpdatedAt,
            DeletedAt = header.DeletedAt,
            MonetaryFund = new MonetaryFundChildDto
            {
                Id = header.MonetaryFund.Id,
                Name = header.MonetaryFund.Name
            },
            DocumentType = new DocumentTypeDto
            {
                Id = header.DocumentType.Id,
                Name = header.DocumentType.Name,
            },
            Details = header.ExpenseDetails.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt,
                UpdatedAt = d.UpdatedAt,
                DeletedAt = d.DeletedAt,
                ExpenseType = new ExpenseTypeDto
                {
                    Id = d.ExpenseType.Id,
                    Name = d.ExpenseType.Name,
                    Code = d.ExpenseType.Code,
                    Description = d.ExpenseType.Description,
                }
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
            if (projected > budget.TotalBudgeted)
            {
                throw new BudgetExceededException(detail.ExpenseTypeId, budget.TotalBudgeted, projected, budget.ExpenseTypeName);
            }
        }
    }
}

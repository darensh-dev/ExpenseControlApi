using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repository;

    public ExpenseService(IExpenseRepository repository)
    {
        _repository = repository;
    }

    public async Task<ExpenseDto> CreateAsync(long userId, ExpenseCreateDto dto)
    {
        var header = new ExpenseHeader
        {
            UserId = userId,
            MonetaryFundId = dto.MonetaryFundId,
            Date = dto.Date,
            MerchantName = dto.MerchantName,
            DocumentTypeId = dto.DocumentTypeId,
            OtherDocumentTypeText = dto.OtherDocumentTypeText,
            Notes = dto.Notes,
            CreatedAt = DateTime.UtcNow
        };

        var details = dto.Details.Select(d => new ExpenseDetail
        {
            ExpenseTypeId = d.ExpenseTypeId,
            Amount = d.Amount,
            CreatedAt = DateTime.UtcNow
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
            Details = details.Select(d => new ExpenseDetailDto
            {
                Id = d.Id,
                ExpenseHeaderId = d.ExpenseHeaderId,
                ExpenseTypeId = d.ExpenseTypeId,
                Amount = d.Amount,
                CreatedAt = d.CreatedAt
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
}

using Microsoft.EntityFrameworkCore;
using ExpenseControlApi.Infrastructure.Data;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.Infrastructure.Repositories;


public class MovementRepository : IMovementRepository
{
    private readonly AppDbContext _context;

    public MovementRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<BudgetExecutionDto>> GetBudgetExecutionAsync(long userId, DateRangeFilterDto dto)
    {
        DateTime startDateTime = dto.StartDate.ToDateTime(TimeOnly.MinValue);
        DateTime endDateTime = dto.EndDate.ToDateTime(TimeOnly.MaxValue);

        var query = @"
            SELECT
                et.name AS ExpenseType,
                b.amount AS BudgetedAmount,
                ed.amount AS ExecutedAmount
            FROM expense_types et
            JOIN budgets b
                ON b.expense_type_id = et.id
                -- AND b.user_id = {2}
                AND b.month >= {0} AND b.month <= {1}
            LEFT JOIN expense_details ed
                ON ed.expense_type_id = et.id
            LEFT JOIN expense_headers eh
                ON eh.id = ed.expense_header_id
                -- AND eh.user_id = {2}
                AND eh.date BETWEEN {0} AND {1}
            WHERE et.deleted_at IS NULL AND et.created_by_user_id = {2};";

        return await _context
            .Set<BudgetExecutionDto>()
            .FromSqlRaw(query, startDateTime, endDateTime, userId)
            .ToListAsync();
    }

    public async Task<List<MovementDto>> GetAllMovimentAsync(long userId, DateRangeFilterDto dto)
    {
        DateTime startDateTime = dto.StartDate.ToDateTime(TimeOnly.MinValue);
        DateTime endDateTime = dto.EndDate.ToDateTime(TimeOnly.MaxValue);

        var query = @"
            SELECT
                'expense' AS MovementType,
                eh.date AS MovementDate,
                mf.name AS FundName,
                dt.name AS DocumentType,
                eh.merchant_name as TradeName,
                et.name AS ExpenseType,
                ed.amount * -1 AS Amount,
                eh.notes as Notes
            FROM expense_headers eh
            INNER JOIN expense_details ed ON ed.expense_header_id = eh.id
            INNER JOIN document_types dt ON dt.id = eh.document_type_id
            INNER JOIN monetary_funds mf ON mf.id = eh.monetary_fund_id
            INNER JOIN expense_types et ON et.id = ed.expense_type_id
            WHERE eh.date BETWEEN {0} AND {1}
                AND eh.deleted_at IS NULL
                AND eh.user_id = {2}
                AND mf.user_id = {2}
                -- AND dt.created_by_user_id = {2}
                -- AND et.created_by_user_id = {2}
            
            UNION  ALL

            -- DEPÓSITOS
            SELECT
                'deposit' AS MovementType,
                d.date AS MovementDate,
                mf.name AS FundName,
                '--/--' AS DocumentType,
                '--/--' AS TradeName,
                '--/--' AS ExpenseType,
                d.amount AS Amount,
                '--/--' AS Notes
            FROM deposits d
            INNER JOIN monetary_funds mf ON mf.id = d.monetary_fund_id
            WHERE d.date BETWEEN {0} AND {1}
                AND d.deleted_at IS NULL
                AND d.user_id = {2}
                AND mf.user_id = {2}
            ORDER BY MovementDate;";

        return await _context
            .Set<MovementDto>()
            .FromSqlRaw(query, startDateTime, endDateTime, userId)
            .ToListAsync();
    }
}

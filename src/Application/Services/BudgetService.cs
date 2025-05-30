// Archivo: src/Application/Services/BudgetService.cs
using ExpenseControlApi.Application.DTOs;
using ExpenseControlApi.Application.Interfaces;
using ExpenseControlApi.Domain.Entities;

namespace ExpenseControlApi.Application.Services;

public class BudgetService // : IBudgetService
{
    private readonly IBudgetRepository _repository;

    public BudgetService(IBudgetRepository repository)
    {
        _repository = repository;
    }

    // public async Task<List<BudgetDto>> GetAllAsync()
    // {
    //     var entities = await _repository.GetAllAsync();
    //     return entities.Select(e => new BudgetDto
    //     {
    //         // Map properties
    //     }).ToList();
    // }

    // public async Task<BudgetDto?> GetByIdAsync(long id)
    // {
    //     var entity = await _repository.GetByIdAsync(id);
    //     if (entity == null) return null;
    //     return new BudgetDto
    //     {
    //         // Map properties
    //     };
    // }

    // public async Task AddAsync(BudgetCreateDto dto)
    // {
    //     var entity = new Budget
    //     {
    //         // Map properties from dto
    //     };
    //     await _repository.AddAsync(entity);
    // }

    // public async Task UpdateAsync(long id, BudgetUpdateDto dto)
    // {
    //     var entity = await _repository.GetByIdAsync(id);
    //     if (entity == null) throw new Exception("Budget not found");
    //     await _repository.UpdateAsync(entity);
    // }

    // public async Task DeleteAsync(long id)
    // {
    //     await _repository.DeleteAsync(id);
    // }
}
using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/expense")]
public class ExpenseController : ControllerBase
{
    private readonly IExpenseService _expenseService;

    public ExpenseController(IExpenseService expenseService)
    {
        _expenseService = expenseService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var headers = await _expenseService.GetAllAsync();
        return Ok(headers);
    }
}

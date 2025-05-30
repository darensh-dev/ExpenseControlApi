using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/expenseheaders")]
public class ExpenseHeadersController : ControllerBase
{
    private readonly IExpenseHeaderService _expenseHeaderService;

    public ExpenseHeadersController(IExpenseHeaderService expenseHeaderService)
    {
        _expenseHeaderService = expenseHeaderService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var headers = await _expenseHeaderService.GetAllAsync();
        return Ok(headers);
    }
}

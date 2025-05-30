using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/fundtypes")]
public class FundTypesController : ControllerBase
{
    private readonly IFundTypeService _fundTypeService;

    public FundTypesController(IFundTypeService fundTypeService)
    {
        _fundTypeService = fundTypeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var types = await _fundTypeService.GetAllAsync();
        return Ok(types);
    }
}

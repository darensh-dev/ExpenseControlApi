using ExpenseControlApi.Application.Services;
using Microsoft.AspNetCore.Mvc;
using ExpenseControlApi.Application.DTOs;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/users")]
public class UsersController : ControllerBase
{
    private readonly UserService _userService;

    public UsersController(UserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserRegisterDto dto)
    {
        try
        {
            await _userService.RegisterAsync(dto);
            return Ok(new { message = "User registered successfully" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}

using ExpenseControlApi.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseControlApi.WebApi.Controllers;

[ApiController]
[Route("api/v1/attachments")]
public class AttachmentsController : ControllerBase
{
    private readonly IAttachmentService _attachmentService;

    public AttachmentsController(IAttachmentService attachmentService)
    {
        _attachmentService = attachmentService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attachments = await _attachmentService.GetAllAsync();
        return Ok(attachments);
    }
}

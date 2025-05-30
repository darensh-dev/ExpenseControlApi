using System.ComponentModel.DataAnnotations;

namespace ExpenseControlApi.Application.DTOs;

public class DocumentTypeDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
}

public class DocumentTypeCreateDto
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;
}



public class PathDocumentTypeDto
{
    [Required(ErrorMessage = "Id is required")]
    public int Id { get; set; } = null!

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = string.Empty;
}

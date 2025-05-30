namespace ExpenseControlApi.Application.DTOs;

public class AttachmentDto
{
    public long Id { get; set; }
    public long ExpenseHeaderId { get; set; }
    public string FileName { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string? ContentType { get; set; }
    public long UploadedByUserId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

public class AttachmentCreateDto
{
    public long ExpenseHeaderId { get; set; }
    public string FileName { get; set; } = null!;
    public string FileUrl { get; set; } = null!;
    public string? ContentType { get; set; }
    public long UploadedByUserId { get; set; }
}

public class AttachmentUpdateDto
{
    public string? FileName { get; set; }
    public string? FileUrl { get; set; }
    public string? ContentType { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}

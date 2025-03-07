using System.ComponentModel.DataAnnotations;

namespace Kazue.Domain.Request.Status;

public class GetStatusRequest
{
    public string? Code { get; set; }
    public string? Description { get; set; } 

    [Required]
    public int Page { get; set; }

    [Required]
    public int PageSize { get; set; }
}

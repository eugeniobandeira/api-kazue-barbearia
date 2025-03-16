using System.ComponentModel.DataAnnotations;

namespace Kazue.Domain.Request.Service;

public class GetServiceRequest
{
    public string? Code { get; set; }
    public string? Description { get; set; }

    [Required]
    public int Page { get; set; }

    [Required]
    public int PageSize { get; set; }
}

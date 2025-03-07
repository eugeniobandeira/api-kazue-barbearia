using System.ComponentModel.DataAnnotations;

namespace Kazue.Domain.Request.Queue;

public class GetQueueRequest
{
    public long IdCustomer { get; set; }
    public long IdBarber { get; set; }
    public long CdService { get; set; }

    [Required]
    public int Page { get; set; }

    [Required]
    public int PageSize { get; set; }
}

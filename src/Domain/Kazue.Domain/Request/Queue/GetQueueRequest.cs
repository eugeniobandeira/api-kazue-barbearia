using System.ComponentModel.DataAnnotations;

namespace Kazue.Domain.Request.Queue;

public class GetQueueRequest
{
    public Guid? IdCustomer { get; set; }
    public Guid? IdBarber { get; set; }

    [Required]
    public int Page { get; set; }

    [Required]
    public int PageSize { get; set; }
}

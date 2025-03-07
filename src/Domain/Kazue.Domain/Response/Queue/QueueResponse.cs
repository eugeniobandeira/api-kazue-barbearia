using Kazue.Domain.Response.Service;
using Kazue.Domain.Response.Shared;
using Kazue.Domain.Response.User;

namespace Kazue.Domain.Response.Queue;

public class QueueResponse
{
    public long Id { get; set; }
    public DateTime DtCheckinAt { get; set; }
    public DateTime? DtCheckoutAt { get; set; }
    public decimal Amount { get; set; }
    public ShortUserResponse Customer { get; set; }
    public ShortUserResponse Barber { get; set; }
    public ItemResponse Status { get; set; }
    public List<ServiceResponse> Services { get; set; }
}

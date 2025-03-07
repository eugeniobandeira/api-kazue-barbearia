namespace Kazue.Domain.Request.Queue;

public class QueueRequest
{
    public long IdCustomer { get; set; }
    public long IdBarber { get; set; }
    public List<string> IdServices { get; set; } = [];
}

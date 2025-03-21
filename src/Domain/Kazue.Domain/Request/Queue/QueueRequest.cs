namespace Kazue.Domain.Request.Queue;

public class QueueRequest
{
    public long IdStatus { get; set; }
    public Guid IdCustomer { get; set; }
    public Guid IdBarber { get; set; }
    public List<string> IdServices { get; set; } = [];
    public decimal Amount { get; set; }
}

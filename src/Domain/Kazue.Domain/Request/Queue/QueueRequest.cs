namespace Kazue.Domain.Request.Queue;

public class QueueRequest
{
    public Guid IdCustomer { get; set; }
    public Guid IdBarber { get; set; }
    public List<string> IdServices { get; set; } = [];
}

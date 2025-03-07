namespace Kazue.Domain.Request.Service;

public class ServiceRequest
{
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
}

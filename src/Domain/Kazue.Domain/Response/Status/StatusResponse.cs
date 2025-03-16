namespace Kazue.Domain.Response.Status;

public class StatusResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

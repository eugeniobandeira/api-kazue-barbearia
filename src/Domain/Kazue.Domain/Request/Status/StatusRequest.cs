﻿namespace Kazue.Domain.Request.Status;

public class StatusRequest
{
    public long IdCategory { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

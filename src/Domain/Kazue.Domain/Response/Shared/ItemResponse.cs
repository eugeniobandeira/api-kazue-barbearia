﻿namespace Kazue.Domain.Response.Shared;

public class ItemResponse
{
    public Guid Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}

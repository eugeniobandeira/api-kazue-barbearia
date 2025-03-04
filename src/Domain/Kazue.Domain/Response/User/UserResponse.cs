﻿namespace Kazue.Domain.Response.Person;

public class UserResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfRegistry { get; set; }
    public long IdStatus { get; set; }
    public string StatusDescription { get; set; } = string.Empty;
}

namespace Kazue.Domain.Response.User;

public class UserResponse
{
    public Guid Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public bool? NicknamePreference { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
    public DateTime DateOfRegistry { get; set; }
    public long IdStatus { get; set; }
    public string StatusCode { get; set; } = string.Empty;
    public string StatusDescription { get; set; } = string.Empty;
}

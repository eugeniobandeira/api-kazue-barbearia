namespace Kazue.Domain.Request.User;

public class CreateUserRequest
{
    public string Fullname { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public bool? NicknamePreference { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime DateOfBirth { get; set; }
}

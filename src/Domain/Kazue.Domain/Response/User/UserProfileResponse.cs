namespace Kazue.Domain.Response.User;

public class UserProfileResponse
{
    public string Fullname { get; set; } = string.Empty;
    public string Nickname { get; set; } = string.Empty;
    public bool NicknamePreference { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
}

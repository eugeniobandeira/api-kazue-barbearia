namespace Kazue.Domain.Response.User;

public class ShortUserResponse
{
    public string Fullname { get; set; } = string.Empty;
    public string? Nickname { get; set; } = string.Empty;
    public bool NicknamePreference { get; set; }

}

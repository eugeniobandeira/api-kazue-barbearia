namespace Kazue.Domain.Response.User;

public class RegisteredUserResponse
{
    public Guid Id { get; set; }
    public string Fullname { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}

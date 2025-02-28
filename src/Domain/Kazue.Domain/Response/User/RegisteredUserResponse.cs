namespace Kazue.Domain.Response.User;

public class RegisteredUserResponse
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Token { get; set; } = string.Empty;
}

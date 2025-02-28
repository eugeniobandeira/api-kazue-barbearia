namespace Kazue.Domain.Interfaces.Security.Token;

public interface ITokenProvider
{
    string TokenOnRequest();
}
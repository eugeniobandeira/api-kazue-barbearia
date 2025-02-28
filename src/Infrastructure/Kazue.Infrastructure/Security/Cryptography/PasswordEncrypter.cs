using Kazue.Domain.Interfaces.Security.Cryptography;

namespace Kazue.Infrastructure.Security.Cryptography;

internal class PasswordEncrypter : IPasswordEncrypter
{
    public string Encrypt(string password)
    {
        string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);

        return passwordHash;
    }

    public bool Verify(string password, string passwordHash)
        => BCrypt.Net.BCrypt.Verify(password, passwordHash);
}

﻿namespace Kazue.Domain.Interfaces.Security.Cryptography;

public interface IPasswordEncrypter
{
    string Encrypt(string password);
    bool Verify(string password, string passwordHash);
}


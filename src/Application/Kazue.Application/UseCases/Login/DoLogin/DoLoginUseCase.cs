using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Cryptography;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Request.Login;
using Kazue.Domain.Response.User;
using Kazue.Exception.ExceptionBase;

namespace Kazue.Application.UseCases.Login.DoLogin;

public class DoLoginUseCase : IDoLoginUseCase
{
    private readonly IReadUserRepository _readUserRepository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    public DoLoginUseCase(
        IReadUserRepository readUserRepository,
        IPasswordEncrypter passwordEncrypter,
        IJwtTokenGenerator jwtTokenGenerator)
    {
        _readUserRepository = readUserRepository;
        _passwordEncrypter = passwordEncrypter;
        _jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<RegisteredUserResponse> ExecuteAsync(LoginRequest req)
    {
        var user = await _readUserRepository.GetByEmail(req.Email) 
                   ?? throw new InvalidLoginException();

        var passwordMatch = _passwordEncrypter.Verify(req.Password, user.DS_PASSWORD);

        if (passwordMatch is false)
            throw new InvalidLoginException();

        return new RegisteredUserResponse
        {
            Id = user.ID_USER,
            Fullname = user.DS_FULLNAME,
            Token = _jwtTokenGenerator.Generate(user)
        };
    }
}

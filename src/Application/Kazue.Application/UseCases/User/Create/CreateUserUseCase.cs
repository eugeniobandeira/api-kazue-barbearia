using Kazue.Domain.Interfaces.Security.Cryptography;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;
using Kazue.Infrastructure.Repository.User;

namespace Kazue.Application.UseCases.User.Create;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public CreateUserUseCase(
        IUserRepository userRepository,
        IPasswordEncrypter passwordEncrypter,
        IJwtTokenGenerator tokenGenerator)
    {
        _userRepository = userRepository;
        _passwordEncrypter = passwordEncrypter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<RegisteredUserResponse> ExecuteAsync(CreateUserRequest req)
    {
        req.Password = _passwordEncrypter.Encrypt(req.Password);

        var repositoryResponse = await _userRepository.Create(req);

        return new RegisteredUserResponse
        {
            Id = repositoryResponse.ID_USER,
            Name = repositoryResponse.DS_NAME,
            Surname = repositoryResponse.DS_SURNAME,
            Token = _tokenGenerator.Generate(repositoryResponse)
        };
    }
}

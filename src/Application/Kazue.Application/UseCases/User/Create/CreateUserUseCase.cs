using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Cryptography;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;

namespace Kazue.Application.UseCases.User.Create;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly ICreateUserRepository _createUserRepository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public CreateUserUseCase(
        ICreateUserRepository createUserRepository,
        IPasswordEncrypter passwordEncrypter,
        IJwtTokenGenerator tokenGenerator)
    {
        _createUserRepository = createUserRepository;
        _passwordEncrypter = passwordEncrypter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<RegisteredUserResponse> ExecuteAsync(CreateUserRequest req)
    {
        req.Password = _passwordEncrypter.Encrypt(req.Password);

        var repositoryResponse = await _createUserRepository.Create(req);

        return new RegisteredUserResponse
        {
            Id = repositoryResponse.ID_USER,
            Name = repositoryResponse.DS_NAME,
            Surname = repositoryResponse.DS_SURNAME,
            Token = _tokenGenerator.Generate(repositoryResponse)
        };
    }
}

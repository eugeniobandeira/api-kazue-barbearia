using FluentValidation.Results;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Cryptography;
using Kazue.Domain.Interfaces.Security.Token;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.User.Create;

public class CreateUserUseCase : ICreateUserUseCase
{
    private readonly ICreateUserRepository _createUserRepository;
    private readonly IReadUserRepository _readUserRepository;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IJwtTokenGenerator _tokenGenerator;

    public CreateUserUseCase(
        ICreateUserRepository createUserRepository,
        IReadUserRepository readUserRepository,
        IPasswordEncrypter passwordEncrypter,
        IJwtTokenGenerator tokenGenerator)
    {
        _createUserRepository = createUserRepository;
        _readUserRepository = readUserRepository;
        _passwordEncrypter = passwordEncrypter;
        _tokenGenerator = tokenGenerator;
    }

    public async Task<RegisteredUserResponse> ExecuteAsync(CreateUserRequest req)
    {
        await Validate(req);

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

    private async Task Validate(CreateUserRequest req)
    {
        var result = new UserValidator().Validate(req);

        var entity = await _readUserRepository.GetByEmail(req.Email);
        if (entity is not null)
        {
            result.Errors.Add(new ValidationFailure(string.Empty, ErrorMessageResource.EMAIL_ALREADY_REGISTERED));
        }

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(error => error.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

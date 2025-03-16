using FluentValidation.Results;
using Kazue.Domain.Entities.User;
using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Security.Cryptography;
using Kazue.Domain.Interfaces.Service.LoggedUser;
using Kazue.Domain.Request.User;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

namespace Kazue.Application.UseCases.User.ChangePassword;

public class ChangePasswordUserUseCase : IChangePasswordUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IPasswordEncrypter _passwordEncrypter;
    private readonly IUpdateUserRepository _updateUserRepository;
    private readonly IReadUserRepository _readUserRepository;

    public ChangePasswordUserUseCase(
        ILoggedUser loggedUser,
        IPasswordEncrypter passwordEncrypter,
        IUpdateUserRepository updateUserRepository,
        IReadUserRepository readUserRepository)
    {
        _loggedUser = loggedUser;
        _passwordEncrypter = passwordEncrypter;
        _updateUserRepository = updateUserRepository;
        _readUserRepository = readUserRepository;
    }

    public async Task ExecuteAsync(Guid id, ChangePasswordRequest req)
    {
        var loggedUser = await _loggedUser.GetAsync();

        Validate(req, loggedUser);

        var user = await _readUserRepository.GetById(loggedUser.ID_USER);
        user.DS_PASSWORD = _passwordEncrypter.Encrypt(req.NewPassword);

        await _updateUserRepository.ChangePasswordAsync(id, req);
    }

    private void Validate(ChangePasswordRequest req, UserEntity loggedUser)
    {
        var validator = new ChangePasswordValidator();

        var result = validator.Validate(req);

        var passwordMatch = _passwordEncrypter.Verify(req.Password, loggedUser.DS_PASSWORD);

        if (!passwordMatch)
            result.Errors.Add(new ValidationFailure(string.Empty, ErrorMessageResource.PASSWORD_DIFFERNT_CURRENT_PASSWORD));

        if (!result.IsValid)
        {
            var errors = result.Errors.Select(error => error.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errors);
        }
    }
}

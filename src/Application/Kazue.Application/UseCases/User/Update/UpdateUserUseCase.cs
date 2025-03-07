using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Service.LoggedUser;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;
using Kazue.Infrastructure.Repository.User;

namespace Kazue.Application.UseCases.User.Update;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    private readonly ILoggedUser _loggedUser;
    private readonly IReadUserRepository _readUserRepository;
    private readonly IUpdateUserRepository _updateUserRepository;

    public UpdateUserUseCase(
        ILoggedUser loggedUser,
        IReadUserRepository readUserRepository,
        IUpdateUserRepository updateUserRepository)
    {
        _loggedUser = loggedUser;
        _readUserRepository = readUserRepository;
        _updateUserRepository = updateUserRepository;
    }
    public async Task<UserProfileResponse> ExecuteAsync(UpdateUserRequest req)
    {
        var loggedUser = await _loggedUser.GetAsync();

        await Validate(req, loggedUser.DS_EMAIL);

        var user = await _readUserRepository.GetById(loggedUser.ID_USER);

        user.DS_NAME = req.Name;
        user.DS_SURNAME = req.Surname;
        user.DS_NICKNAME = req.Nickname;
        user.DS_EMAIL = req.Email;
        user.DS_PHONE = req.Phone;

        _updateUserRepository.Update(user);

        return new UserProfileResponse
        {
            Name = user.DS_NAME,
            Surname = user.DS_SURNAME,
            Email = user.DS_EMAIL,
            Nickname = user.DS_NICKNAME,
            Phone = user.DS_PHONE
        };
    }

    private async Task Validate(UpdateUserRequest req, string currentEmail)
    {
        var validator = new UpdateUserValidator();

        var result = validator.Validate(req);

        if (!currentEmail.Equals(req.Email))
        {
            var userExist = await _readUserRepository.GetByEmail(req.Email);
            if (userExist is not null)
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ErrorMessageResource.EMAIL_ALREADY_REGISTERED));
        }

        if (!result.IsValid)
        {
            var errorMessage = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessage);
        }
    }

}

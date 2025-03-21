using Kazue.Domain.Interfaces.Infrastructure.Repository.User;
using Kazue.Domain.Interfaces.Service.LoggedUser;
using Kazue.Domain.Request.User;
using Kazue.Domain.Response.User;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;

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
    public async Task<UserProfileResponse> ExecuteAsync(Guid id, UpdateUserRequest req)
    {
        var loggedUser = await _loggedUser.GetAsync();

        await Validate(req, loggedUser.DS_EMAIL);

        var user = await _readUserRepository.GetById(loggedUser.ID_USER);

        //user.DS_FULLNAME = req.Fullname;
        //user.DS_NICKNAME = req.Nickname;
        //user.CK_NICKNAME_PREFERENCE = req.NicknamePreference ?? false;
        //user.DS_EMAIL = req.Email;
        //user.DS_PHONE = req.Phone;

        await _updateUserRepository.UpdateAsync(id, req);

        return new UserProfileResponse
        {
            Fullname = user.DS_FULLNAME,
            Email = user.DS_EMAIL,
            Nickname = user.DS_NICKNAME,
            NicknamePreference = user.CK_NICKNAME_PREFERENCE,
            Phone = user.DS_PHONE,
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
                result
                    .Errors
                    .Add(new FluentValidation
                        .Results
                        .ValidationFailure(string.Empty, ErrorMessageResource.EMAIL_ALREADY_REGISTERED));
        }

        if (!result.IsValid)
        {
            var errorMessage = result.Errors.Select(err => err.ErrorMessage).ToList();
            throw new ErrorOnValidationException(errorMessage);
        }
    }

}

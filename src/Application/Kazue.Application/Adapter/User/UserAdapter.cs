using Kazue.Domain.Entities.User;
using Kazue.Domain.Response.User;

namespace Kazue.Application.Adapter.User;

public static class UserAdapter
{
    public static UserResponse FromEntityToResponse(UserEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException(nameof(entity), "Cannot adapt a null entity to response");

        var response = new UserResponse()
        {
            Id = entity.ID_USER,
            Fullname = entity.DS_FULLNAME,
            Nickname = entity.DS_NICKNAME,
            NicknamePreference = entity.CK_NICKNAME_PREFERENCE,
            Email = entity.DS_EMAIL,
            Phone = entity.DS_PHONE,
            Role = entity.DS_ROLE,
            IdStatus = entity.ID_STATUS,
            StatusCode = entity.CD_STATUS,
            StatusDescription = entity.DS_STATUS,
            DateOfBirth = entity.DT_BIRTH,
            DateOfRegistry = entity.DT_REGISTRY
        };

        return response;
    }
}

using Kazue.Domain.Entities.User;
using Kazue.Domain.Response.User;

namespace Kazue.Application.Adapter.User;

public static class UserAdapter
{
    public static UserResponse FromEntityToResponse(UserEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException("Cannot adapt a null entity to response", nameof(entity));

        var response = new UserResponse()
        {
            Id = entity.ID_USER,
            Surname = entity.DS_SURNAME,
            Nickname = entity.DS_NICKNAME,
            Email = entity.DS_EMAIL,
            Phone = entity.DS_PHONE,
            Name = entity.DS_NAME,
            Role = entity.DS_ROLE,
            IdStatus = entity.ID_STATUS,
            StatusDescription = entity.DS_STATUS,
            DateOfBirth = entity.DT_BIRTH,
            DateOfRegistry = entity.DT_REGISTRY
        };

        return response;
    }
}

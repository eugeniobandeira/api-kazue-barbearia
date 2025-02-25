using Kazue.Domain.Entities.Barber;
using Kazue.Domain.Response.Person;

namespace Kazue.Application.Adapter.Barber;

public static class BarberAdapter
{
    public static RegisteredPersonResponse FromEntityToResponse(BarberEntity? entity)
    {
        if (entity is null)
            throw new ArgumentNullException("Cannot adapt a null entity to response", nameof(entity));

        var response = new RegisteredPersonResponse()
        {
            Id = entity.ID_BARBER,
            Surname = entity.DS_ROLE,
            Nickname = entity.DS_NICKNAME,
            Email = entity.DS_EMAIL,
            Phone = entity.DS_PHONE,
            Name = entity.DS_NAME,
            Status = entity.TP_STATUS,
            DateOfBirth = entity.DT_BIRTH,
            DateOfRegistry = entity.DT_REGISTRY
        };

        return response;
    }
}

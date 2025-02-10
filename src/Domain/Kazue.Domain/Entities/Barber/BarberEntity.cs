using Kazue.Domain.Entities.Person;
using Kazue.Domain.Helper;

namespace Kazue.Domain.Entities.Barber;

public class BarberEntity : PersonEntity
{
    public string Role { get; set; } = RolesHelper.ADMIN;
    public Guid BarberGuid { get; set; }
}

using Kazue.Domain.Entities.Person;
using Kazue.Domain.Helper;

namespace Kazue.Domain.Entities.Barber;

public class BarberEntity : PersonEntity
{
    public long ID_BARBER { get; set; }
    public string DS_ROLE { get; set; } = RolesHelper.ADMIN;
}

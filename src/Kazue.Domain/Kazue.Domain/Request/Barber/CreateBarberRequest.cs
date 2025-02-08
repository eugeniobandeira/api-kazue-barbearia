using Kazue.Domain.Helper;
using Kazue.Domain.Request.Person;

namespace Kazue.Domain.Request.Barber;

public class CreateBarberRequest : PersonRequest
{
    public string Role { get; set; } = RolesHelper.ADMIN;
}

using Kazue.Domain.Request.Person;

namespace Kazue.Domain.Request.Barber;

public class UpdateBarberRequest : PersonRequest
{
    public long Id { get; set; }
}

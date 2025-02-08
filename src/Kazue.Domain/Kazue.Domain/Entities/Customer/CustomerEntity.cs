using Kazue.Domain.Entities.Person;
using Kazue.Domain.Helper;

namespace Kazue.Domain.Entities.Customer;

public class CustomerEntity : PersonEntity
{
    public string Role { get; set; } = RolesHelper.USER;
    public Guid CustomerGuid  { get; set; }
}

using Kazue.Domain.Entities.Person;
using Kazue.Domain.Helper;

namespace Kazue.Domain.Entities.Customer;

public class CustomerEntity : PersonEntity
{
    public long ID_CUSTOMER { get; set; }
    public string DS_ROLE { get; set; } = RolesHelper.USER;
}

using Kazue.Domain.Helper;
using Kazue.Domain.Request.Person;

namespace Kazue.Domain.Request.Customer;

public class CreateCustomerRequest : PersonRequest
{
    public string Role { get; set; } = RolesHelper.USER;
}

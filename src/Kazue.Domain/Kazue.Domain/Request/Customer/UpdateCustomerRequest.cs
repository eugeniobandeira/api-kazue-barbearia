using Kazue.Domain.Request.Person;

namespace Kazue.Domain.Request.Customer;

public class UpdateCustomerRequest : PersonRequest
{
    public long Id { get; set; }
}

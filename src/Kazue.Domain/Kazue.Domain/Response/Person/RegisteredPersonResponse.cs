using Kazue.Domain.Helper;

namespace Kazue.Domain.Response.Person;

public abstract class PersonResponse
{
    public string NM_PERSON { get; set; } = string.Empty;
    public string DS_TOKEN { get; set; } = string.Empty;
}

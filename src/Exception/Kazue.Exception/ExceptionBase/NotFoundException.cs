using System.Net;

namespace Kazue.Exception.ExceptionBase;

public class NotFoundException : KazueException
{
    public NotFoundException(string message) : base(message) { }

    public override int StatusCode
        => (int)HttpStatusCode.NotFound;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}

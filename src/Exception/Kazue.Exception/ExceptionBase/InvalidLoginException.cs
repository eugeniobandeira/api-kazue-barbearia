using System.Net;
using Kazue.Exception.MessageResource;

namespace Kazue.Exception.ExceptionBase;

public class InvalidLoginException : KazueException
{
    public InvalidLoginException() : base(ErrorMessageResource.INVALID_EMAIL_OR_PASSWORD) { }

    public override int StatusCode
        => (int)HttpStatusCode.Unauthorized;

    public override List<string> GetErrors()
    {
        return [Message];
    }
}

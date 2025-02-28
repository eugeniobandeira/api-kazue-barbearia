using System.Net;

namespace Kazue.Exception.ExceptionBase;

public class ErrorOnValidationException : KazueException
{
    private readonly List<string> _errors;

    public ErrorOnValidationException(List<string> errorMesage) : base(string.Empty)
    {
        _errors = errorMesage;
    }

    public override int StatusCode
        => (int)HttpStatusCode.BadRequest;

    public override List<string> GetErrors()
    {
        return _errors;
    }
        
}

namespace Kazue.Exception.ExceptionBase; 
public abstract class KazueException : SystemException
{
    protected KazueException(string message) : base(message) { }

    public abstract int StatusCode { get; }
    public abstract List<string> GetErrors();

}


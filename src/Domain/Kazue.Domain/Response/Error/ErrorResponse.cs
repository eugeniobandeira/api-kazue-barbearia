namespace Kazue.Domain.Response.Error;

public class ErrorResponse
{
    public List<string> ErrorMessage { get; set; }

    public ErrorResponse(string errorMessage)
    {
        ErrorMessage = [errorMessage];
    }

    public ErrorResponse(List<string> errorMessage)
    {
        ErrorMessage = errorMessage ?? [];
    }
}

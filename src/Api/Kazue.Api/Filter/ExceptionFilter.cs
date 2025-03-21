using Kazue.Domain.Response.Error;
using Kazue.Exception.ExceptionBase;
using Kazue.Exception.MessageResource;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Kazue.Api.Filter;

public class ExceptionFilter : IExceptionFilter
{
    /// <summary>
    /// Exception treatment
    /// </summary>
    /// <param name="context"></param>
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is KazueException)
        {
            HandleProjectException(context);
        }
        else
        {
            ThrowUnknownError(context);
        }
    }

    private static void HandleProjectException(ExceptionContext context)
    {
        var exception = context.Exception as KazueException;
        var errorResponse = new ErrorResponse(exception!.GetErrors());

        context.HttpContext.Response.StatusCode = exception.StatusCode;
        context.Result = new ObjectResult(errorResponse);
    }

    private static void ThrowUnknownError(ExceptionContext context)
    {
        var errorResponse = new ErrorResponse(ErrorMessageResource.UNKNOWN_ERROR);

        context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
        context.Result = new ObjectResult(errorResponse);
    }
}

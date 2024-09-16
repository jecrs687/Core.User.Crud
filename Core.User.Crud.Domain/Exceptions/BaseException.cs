using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Exceptions;

public abstract class BaseException(string message, int statusCode) : Exception(message), IActionResult
{
    public int StatusCode { get; set; } = statusCode;

    public Task ExecuteResultAsync(ActionContext context)
    {
        var objectResult = new ObjectResult(new
        {
            error = Message,
            stackTrace = StackTrace
        })
        {
            StatusCode = StatusCode
        };

        return objectResult.ExecuteResultAsync(context);
    }
}
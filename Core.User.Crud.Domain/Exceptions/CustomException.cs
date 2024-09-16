using Core.User.Crud.Domain.Exceptions.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Core.User.Crud.Domain.Exceptions;

public static class CustomException
{
    public static int UserExceptions(this ExceptionContext context)
    {
        return context.Exception switch
        {
            UserNotFoundException => UserNotFoundException.StatusCode,
            UserAlreadyExistsException => UserAlreadyExistsException.StatusCode,
            UserEmailInvalidException => UserEmailInvalidException.StatusCode,
            BirthDateInvalidUnder18Exception => BirthDateInvalidUnder18Exception.StatusCode,
            _ => StatusCodes.Status500InternalServerError
        };
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Exceptions.User;

public class UserNotFoundException(Guid id)
    : BaseException(UserMessagesException.UserNotFound(id), StatusCodes.Status404NotFound)
{
    public static int StatusCode  = StatusCodes.Status404NotFound;
}

public class BirthDateInvalidUnder18Exception()
    : BaseException(UserMessagesException.BirthDateInvalidUnder18(), StatusCodes.Status400BadRequest)
{
    public static int StatusCode  = StatusCodes.Status400BadRequest;
}

public class UserAlreadyExistsException(string email)
    : BaseException(UserMessagesException.UserAlreadyExists(email), StatusCodes.Status409Conflict)
{
    public static int StatusCode = StatusCodes.Status400BadRequest;
}

public class UserEmailInvalidException(string email)
    : BaseException(UserMessagesException.UserEmailInvalid(email), StatusCodes.Status400BadRequest)
{
    public static int StatusCode  = StatusCodes.Status400BadRequest;
}
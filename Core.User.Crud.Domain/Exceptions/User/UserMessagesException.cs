namespace Core.User.Crud.Domain.Exceptions.User;

public static class UserMessagesException
{ 
    public static string UserNotFound(Guid id) => $"User with id {id} not found";
    public static string BirthDateInvalidUnder18() => "User must be at least 18 years old";
    public static string UserAlreadyExists(string email) => $"User with email {email} already exists";
    public static string UserEmailInvalid(string email) => $"User email {email} is invalid";
}

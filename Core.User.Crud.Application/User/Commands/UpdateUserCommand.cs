using Core.User.Crud.Domain.Entities;

namespace Core.User.Crud.Domain.commands;

public class UpdateUserCommand: UserEntity
{   
    
    public UpdateUserCommand WithFirstName(string firstName)
    {
        FirstName = firstName;
        return this;
    }
    
    public UpdateUserCommand WithLastName(string lastName)
    {
        LastName = lastName;
        return this;
    }
    
    public UpdateUserCommand WithDateOfBirth(DateTime dateOfBirth)
    {
        DateOfBirth = dateOfBirth;
        return this;
    }
    
    public UpdateUserCommand WithEmail(string email)
    {
        Email = email;
        return this;
    }
}
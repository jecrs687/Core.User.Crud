using Core.User.Crud.Application.User.Requests;
using Core.User.Crud.Domain.Entities;

namespace  Core.User.Crud.Application.User.Commands;
public class CreateUserCommand
{ 
    public CreateUserRequest Request { get; set; }
    public UserEntity ToEntity()
    {
        return new UserEntity
        {
            FirstName = Request.FirstName,
            LastName = Request.LastName,
            DateOfBirth = Request.DateOfBirth,
            Email = Request.Email
        };
    }
    
    public CreateUserCommand WithRequest(CreateUserRequest request)
    {
        Request = request;
        return this;
    }
    
    
}
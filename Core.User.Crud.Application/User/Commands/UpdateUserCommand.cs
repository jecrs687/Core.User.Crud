using Core.User.Crud.Application.User.Requests;
using Core.User.Crud.Domain.Entities;

namespace Core.User.Crud.Application.User.Commands;

public class UpdateUserCommand: UserEntity
{  
    public Guid Id { get; set; }
    public UpdateUserRequest Request { get; set; }

    public UserEntity ToEntity()
    {
        return new UserEntity()
        {
            Id = Id,
            DateOfBirth = Request.DateOfBirth,
            LastName = Request.LastName,
            Email = Request.Email,
            FirstName = Request.FirstName
        };
    }

    public UpdateUserCommand WithId(Guid id)
    {
        Id = id;
        return this;
    }
    
    public UpdateUserCommand WithRequest(UpdateUserRequest name)
    {
        Request = name;
        return this;
    }
}
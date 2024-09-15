using Core.User.Crud.Domain.Requests.User;

namespace Core.User.Crud.Domain.commands;
public class CreateUserCommand
{ 
    public CreateUserRequest? Request { get; set; }
    
    public CreateUserCommand WithRequest(CreateUserRequest request)
    {
        Request = request;
        return this;
    }
    
    
}
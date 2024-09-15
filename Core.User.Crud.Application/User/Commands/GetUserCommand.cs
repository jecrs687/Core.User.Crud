namespace Core.User.Crud.Domain.commands;

public class GetUserCommand
{
    Guid Id { get; set; }
    
    public GetUserCommand WithId(Guid id)
    {
        Id = id;
        return this;
    }
    
}
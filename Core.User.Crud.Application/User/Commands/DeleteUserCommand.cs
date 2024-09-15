namespace Core.User.Crud.Domain.commands;

public class DeleteUserCommand
{
    Guid Id { get; set; }
    
    public DeleteUserCommand WithId(Guid id)
    {
        Id = id;
        return this;
    }
}
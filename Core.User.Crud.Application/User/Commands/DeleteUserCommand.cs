namespace   Core.User.Crud.Application.User.Commands;

public class DeleteUserCommand
{
    public Guid Id { get; set; }
    
    public DeleteUserCommand WithId(Guid id)
    {
        Id = id;
        return this;
    }
}
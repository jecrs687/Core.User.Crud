namespace   Core.User.Crud.Application.User.Commands;

public class GetUserCommand
{
    public Guid Id { get; set; }
    
    public GetUserCommand WithId(Guid id)
    {
        Id = id;
        return this;
    }
    
}
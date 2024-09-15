using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Requests.User;

public class DeleteUserParams
{
    [FromRoute]
    public Guid Id { get; set; }
}
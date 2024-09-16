using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Params;

public class DeleteUserParams
{
    [FromRoute]
    public Guid Id { get; set; }
}
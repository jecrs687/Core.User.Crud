using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Params;

public class UpdateUserParams
{
    [FromRoute]
    public Guid Id { get; set; }
}
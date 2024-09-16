using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Params;

public class GetUserParams
{
    [FromRoute]
    public Guid Id { get; set; }
}
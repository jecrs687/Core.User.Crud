using Microsoft.AspNetCore.Mvc;

namespace Core.User.Crud.Domain.Requests.User;

public class GetUserParams
{
    [FromRoute]
    public Guid Id { get; set; }
}